#pragma warning disable 0649

using System;
using System.Collections;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.Assistant.V2;
using IBM.Watson.Assistant.V2.Model;
using UnityEngine;
using UnityEngine.UI;

public class SimpleBot : MonoBehaviour
{
    [SerializeField]
    private WatsonSettings settings;

    private AssistantService Assistant_service;

    private bool createSessionTested = false;

    // 2020/2/15 Changed to protected to be accessible in CommandBot.cs
    protected bool messageTested = false;
    private bool deleteSessionTested = false;
    private string sessionId;

    public string textResponse = String.Empty;

    [SerializeField]
    private InputField targetInputField;

    [SerializeField]
    private Text targetText;

    public bool userNameType, userNameSet;


    //Keep track of whether IBM Watson Assistant should process input or is
    //processing input to create a chat response.
    public enum ProcessingStatus { Process, Processing, Idle, Processed };
    private ProcessingStatus chatStatus;

    public enum InputFieldTrigger { onValueChanged, onEndEdit };

    [SerializeField]
    private InputField externalInputField;
    [SerializeField]
    private InputFieldTrigger externalTriggerType;

    private InputField inputField;

    // The output target GameObject to receive text from this gameObject.
    [SerializeField]
    private GameObject targetGameObject;

    public static string userInputNameVoice = "";


    private void Start()
    {
        print("Enable");
        // Enable TLS 1.2
        //ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

        // Disable old protocols
        //ServicePointManager.SecurityProtocol &= ~(SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11);

        LogSystem.InstallDefaultReactors();
        Runnable.Run(CreateService());
        chatStatus = ProcessingStatus.Idle;

        // Since coroutines can't return values I use the onValueChanged listener
        // to trigger an action after waiting for an input to arrive.
        // I originally used enums or flags to keep track if a process such
        // as obtaining a chat response from IBM Assistant was still being processed
        // or was finished processing but this was cumbersome.

        if (externalInputField != null)
        {
            if (externalTriggerType == InputFieldTrigger.onEndEdit)
            {
                externalInputField.onEndEdit.AddListener(delegate { Runnable.Run(ProcessChat(externalInputField.text)); });
            }
            else
            {
                externalInputField.onValueChanged.AddListener(delegate { Runnable.Run(ProcessChat(externalInputField.text)); });
            }
        }

        inputField = gameObject.AddComponent<InputField>();
        inputField.textComponent = gameObject.AddComponent<Text>();
        inputField.onValueChanged.AddListener(delegate { Runnable.Run(ProcessChat(inputField.text)); });
    }

    public IEnumerator CreateService()
    {

        if (string.IsNullOrEmpty(settings.Assistant_apikey))
        {
            throw new IBMException("Please provide Watson Assistant IAM ApiKey for the service.");
        }

        //  Create credential and instantiate service
        //            IamAuthenticator authenticator = new IamAuthenticator(apikey: Assistant_apikey, url: serviceUrl);
        IamAuthenticator authenticator = new IamAuthenticator(apikey: settings.Assistant_apikey);

        //  Wait for tokendata
        while (!authenticator.CanAuthenticate())
            yield return null;

        Assistant_service = new AssistantService(settings.versionDate, authenticator);
        if (!string.IsNullOrEmpty(settings.serviceUrl))
        {
            Assistant_service.SetServiceUrl(settings.serviceUrl);
        }

        Assistant_service.CreateSession(OnCreateSession, settings.assistantId);
        while (!createSessionTested)
        {
            yield return null;
        }
    }

    // Get the "welcome" chat reponse from IBM Watson Assistant
    public IEnumerator Welcome()
    {
        // Set chat processing status to "Processing"
        chatStatus = ProcessingStatus.Processing;

        while (!createSessionTested)
        {
            yield return null;
        }

        Assistant_service.MessageIOS(OnMessageIOS, settings.assistantId, sessionId);
        while (!messageTested)
        {
            messageTested = false;
            yield return null;
        }

        if (!String.IsNullOrEmpty(textResponse))
        {
            // Set status to show chat processing has finished 
            chatStatus = ProcessingStatus.Processed;
        }

    }


    //private void OnDisable()
    //{
    //    print("Disable");
    //    Assistant_service.DeleteSessionMod(OnDeleteSession, settings.assistantId, sessionId);

    //}


    public void GetChatResponse(string chatInput)
    {
        StartCoroutine(ProcessChat(chatInput));
    }

    public IEnumerator ProcessChat(string chatInput)
    {
        Debug.Log("Processchat: 163" + chatInput);

        // Set status to show that the chat input is being processed.
        chatStatus = ProcessingStatus.Processing;

        if (Assistant_service == null)
        {
            yield return null;
        }
        if (String.IsNullOrEmpty(chatInput))
        {
            yield return null;
        }

        messageTested = false;

        if (chatInput.Length < 12 && userNameType)
        {
            userNameSet = true;
            userNameType = false;
            //fh
            userInputNameVoice = chatInput;
            chatInput = "اسم المستخدم";

            var inputMessage = new MessageInput()
            {

                Text = chatInput,
                Options = new MessageInputOptions()
                {
                    ReturnContext = true
                }
            };
            Assistant_service.MessageIOS(OnMessageIOS, settings.assistantId, sessionId, input: inputMessage);

           // UIManagerScript.instance.SendMessageServer(userInputName);
        }
        else
        {
            var inputMessage = new MessageInput()
            {
                Text = chatInput,
                Options = new MessageInputOptions()
                {
                    ReturnContext = true
                }
            };

            Assistant_service.MessageIOS(OnMessageIOS, settings.assistantId, sessionId, input: inputMessage);
        }

        while (!messageTested)
        {
            messageTested = false;
            yield return null;
        }

        if (!String.IsNullOrEmpty(textResponse))
        {
            // Set status to show chat processing has finished.
            chatStatus = ProcessingStatus.Processed;
        }
    }

    private void OnDeleteSession(DetailedResponse<MyRootClass> response, IBMError error)
    {
        deleteSessionTested = true;
    }

    // This is where the returned chat response is set to send as output
    protected virtual void OnMessage(DetailedResponse<MessageResponse> response, IBMError error)
    {
        textResponse = response.Result.Output.Generic[0].Text.ToString();

        if (targetInputField != null)
        {
            targetInputField.text = textResponse;
        }

        // Check if the target GameObject has an InputField then place text into it.
        if (targetGameObject != null)
        {
            InputField target = targetGameObject.GetComponent<InputField>();
            if (target != null)
            {
                target.text = textResponse;
            }
        }

        Debug.Log(textResponse);
        messageTested = true;
    }

    /// <summary>
    /// IOS 
    /// </summary>
    /// <param name="response"></param>
    /// <param name="error"></param>
    /// 
    string[] arr;

    protected virtual void OnMessageIOS(DetailedResponse<MyRootClass> response, IBMError error)
    {
        textResponse = response.Result.output.generic[0].text.ToString();

        if (!userNameSet)
        {
            userNameType = true;
        }


        if (textResponse.Contains("*name"))
        {
            textResponse = textResponse.Replace("*name", userInputNameVoice);
            //print("280 >>> " + userInputNameVoice);
            //print("281>> "+textResponse);
        }

        if (textResponse.Contains("http"))
        {
            arr = textResponse.Split('<');

            if (targetInputField != null)
            {
                targetInputField.text = arr[0];
            }

            // Check if the target GameObject has an InputField then place text into it.
            if (targetGameObject != null)
            {
                InputField target = targetGameObject.GetComponent<InputField>();
                if (target != null)
                {
                    target.text = arr[0];
                }
            }

            Debug.Log(arr[0]);
            messageTested = true;
        }
        else
        {
            if (targetInputField != null)
            {
                targetInputField.text = textResponse;
            }

            // Check if the target GameObject has an InputField then place text into it.
            if (targetGameObject != null)
            {
                InputField target = targetGameObject.GetComponent<InputField>();
                if (target != null)
                {
                    target.text = textResponse;
                }
            }

            Debug.Log(textResponse);
            messageTested = true;
        }

    }



    private void OnCreateSession(DetailedResponse<SessionResponse> response, IBMError error)
    {
        Log.Debug("SimpleBot.OnCreateSession()", "Session: {0}", response.Result.SessionId);
        sessionId = response.Result.SessionId;
        createSessionTested = true;
    }

    public void SetChatStatus(ProcessingStatus status)
    {
        chatStatus = status;
    }

    public ProcessingStatus GetStatus()
    {
        return chatStatus;
    }

    public bool ServiceReady()
    {
        return createSessionTested;
    }

    public string GetResult()
    {
        chatStatus = ProcessingStatus.Idle;
        return textResponse;
    }

}

