#pragma warning disable 0649
using System;
using System.Collections;
using System.Collections.Generic;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.TextToSpeech.V1;
using UnityEngine;
using UnityEngine.UI;

public class BotTextToSpeechScript : MonoBehaviour
{
    [SerializeField]
    private WatsonSettings settings;

    /* for other languages at:
     * https://cloud.ibm.com/docs/text-to-speech?topic=text-to-speech-voices#voices
     */
    public enum IBM_voices
    {
        GB_KateV3Voice,
        US_EmilyV3Voice,
        AR_OmarVoice
    }
    [SerializeField]
    private IBM_voices voice = IBM_voices.GB_KateV3Voice;

    private TextToSpeechService tts_service; // IBM Watson text to speech service
    private IamAuthenticator tts_authenticator; // IBM Watson text to speech authenticator

    //Keep track of when the processing of text to speech is complete.
    //I don't want processing of text to speech to start until the previous 
    //text is processed. Otherwise, short text samples get processed faster
    //than longer samples and may be placed on the queue out of order.
    //It seems that AudioSource.isPlaying doesn't work reliably.
    public enum ProcessingStatus { Processing, Idle };
    private ProcessingStatus audioStatus;

    [SerializeField]
    private AudioSource outputAudioSource; // The AudioSource for speaking

    // A queue for storing the entered texts for conversion to speech audio files
    private Queue<string> textQueue = new Queue<string>();
    // A queue for storing the speech AudioClips for playing
    private Queue<AudioClip> audioQueue = new Queue<AudioClip>();

    private InputField inputField;

    public GameObject loadingPanel;

    public bool playOnce = true;

    private void OnEnable()
    {
        if (outputAudioSource == null)
        {
            outputAudioSource = GameObject.Find("Mesh_bot").GetComponent<AudioSource>();
        }
    }

    private void OnDisable()
    {
        if (outputAudioSource != null)
        {
            outputAudioSource.Stop();
        }
        //outputAudioSource.clip = null;
        //outputAudioSource = null;
    }

    private void Start()
    {
        audioStatus = ProcessingStatus.Idle;
        LogSystem.InstallDefaultReactors();
        Runnable.Run(CreateService());

        // Get or make the AudioSource for playing the speech
        if (outputAudioSource == null)
        {
            gameObject.AddComponent<AudioSource>();
            outputAudioSource = gameObject.GetComponent<AudioSource>();
        }

        inputField = gameObject.AddComponent<InputField>();
        inputField.textComponent = gameObject.AddComponent<Text>();
        inputField.onValueChanged.AddListener(delegate { AddTextToQueue(inputField.text); });
    }

    private void Update()
    {
        // If no AudioClip is playing, convert the next text phrase to
        // audio audio if there is any left in the text queue.
        // The new audio clip is placed into the audio queue.
        if (textQueue.Count > 0 && audioStatus == ProcessingStatus.Idle)
        {
            Debug.Log("Run ProcessText");
            Runnable.Run(ProcessText());
        }

        // If no AudioClip is playing, remove the next clip from the
        // queue and play it.
        if (audioQueue.Count > 0 && !outputAudioSource.isPlaying)
        {
            PlayClip(audioQueue.Dequeue());
        }

    }

    // Create the IBM text to speech service
    public IEnumerator CreateService()
    {
        //  Create credential and instantiate service
        tts_authenticator = new IamAuthenticator(apikey: settings.tts_apikey);

        //  Wait for tokendata
        while (!tts_authenticator.CanAuthenticate())
            yield return null;

        tts_service = new TextToSpeechService(tts_authenticator);
        if (!string.IsNullOrEmpty(settings.tts_serviceUrl))
        {
            tts_service.SetServiceUrl(settings.tts_serviceUrl);
        }
    }

    private IEnumerator ProcessText()
    {
        loadingPanel.SetActive(false);

        Debug.Log("ProcessText");

        if (playOnce)
        {
            AnimationChangerScript.instance.ChangeAnim();
            playOnce = false;
        }

        string nextText = String.Empty;

        audioStatus = ProcessingStatus.Processing;

        if (outputAudioSource.isPlaying)
        {
            yield return null;
        }

        if (textQueue.Count < 1)
        {
            yield return null;
        }
        else
        {
            nextText = textQueue.Dequeue();
            Debug.Log(nextText);

            if (String.IsNullOrEmpty(nextText))
            {
                yield return null;
            }
        }

        byte[] synthesizeResponse = null;
        AudioClip clip = null;
        if (voice == IBM_voices.AR_OmarVoice)
        {
            tts_service.Synthesize(
                callback: (DetailedResponse<byte[]> response, IBMError error) =>
                {
                    synthesizeResponse = response.Result;
                    clip = WaveFile.ParseWAV("myClip", synthesizeResponse);

                    //Place the new clip into the audio queue.
                    audioQueue.Enqueue(clip);
                },
                text: nextText,
                voice: "ar-" + voice,
                accept: "audio/wav"
            );
        }
        else
        {

            tts_service.Synthesize(
                callback: (DetailedResponse<byte[]> response, IBMError error) =>
                {
                    synthesizeResponse = response.Result;
                    clip = WaveFile.ParseWAV("myClip", synthesizeResponse);

                    //Place the new clip into the audio queue.
                    audioQueue.Enqueue(clip);
                },
                text: nextText,
                voice: "en-" + voice,
                accept: "audio/wav"
            );

        }

        while (synthesizeResponse == null)
            yield return null;

        // Set status to indicate text to speech processing task completed
        audioStatus = ProcessingStatus.Idle;

    }

    private void PlayClip(AudioClip clip)
    {
        if (Application.isPlaying && clip != null)
        {
            outputAudioSource.spatialBlend = 0.0f;
            outputAudioSource.loop = false;
            outputAudioSource.clip = clip;
            outputAudioSource.Play();
        }
    }

    // Add a text sample to the text queue to be converted into audio
    public void AddTextToQueue(string text)
    {
        Debug.Log("AddTextToQueue: " + text);
        if (!string.IsNullOrEmpty(text))
        {
            textQueue.Enqueue(text);
            inputField.text = string.Empty;
        }

    }

    // Return the status of the conversion to audio
    public ProcessingStatus Status()
    {
        return audioStatus;
    }

    // Check if the text to speech service is ready
    public bool ServiceReady()
    {
        return tts_service != null;
    }

    public bool IsFinished()
    {
        return !outputAudioSource.isPlaying && audioQueue.Count < 1 && textQueue.Count < 1;
    }
}
