using System;
using System.Collections;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.Assistant.V2;
using IBM.Watson.Assistant.V2.Model;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextChatBot : MonoBehaviour
{
    [SerializeField]
    private WatsonSettings settings;

    private AssistantService Assistant_service;

    private bool createSessionTested = false;

    protected bool messageTested = false;
    private bool deleteSessionTested = false;
    private string sessionId;

    public string textResponse = String.Empty;

    //Keep track of whether IBM Watson Assistant should process input or is
    //processing input to create a chat response.
    public enum ProcessingStatus { Process, Processing, Idle, Processed };
    private ProcessingStatus chatStatus;

    [SerializeField] private TMP_InputField externalInputFieldTest;

    private InputField inputField;


    public Button sendBtn;
    public GameObject loadingPanel;

    public static string userInputName="";

    private void Start()
    {
        UIManagerScript.instance.serverConnectionPanelTextChat.SetActive(true);

        LogSystem.InstallDefaultReactors();
        Runnable.Run(CreateService());
        chatStatus = ProcessingStatus.Idle;

        // Since coroutines can't return values I use the onValueChanged listener
        // to trigger an action after waiting for an input to arrive.
        // I originally used enums or flags to keep track if a process such
        // as obtaining a chat response from IBM Assistant was still being processed
        // or was finished processing but this was cumbersome.

        if (externalInputFieldTest != null)
        {
            sendBtn.onClick.AddListener(delegate { Runnable.Run(ProcessChat(externalInputFieldTest.text)); });
        }
        
        inputField = gameObject.AddComponent<InputField>();
        inputField.textComponent = gameObject.AddComponent<Text>();
        inputField.onValueChanged.AddListener(delegate { Runnable.Run(ProcessChat(inputField.text)); });
        

        StartCoroutine(Welcome());

    }
    //public static void OnSDisable()
    //{
    //    print("Disable");
    //    TextChatBot textChatBot = new TextChatBot();
    //    textChatBot.inputField.onValueChanged.RemoveListener(delegate { Runnable.Run(textChatBot.ProcessChat(textChatBot.inputField.text)); });
    //    textChatBot. inputField.textComponent = null;
    //    textChatBot.inputField = null;
    //    Destroy(textChatBot.GetComponent<InputField>());
    //    Destroy(textChatBot.GetComponent<Text>());

    //    textChatBot.Assistant_service.DeleteSessionMod(textChatBot.OnDeleteSession, textChatBot.settings.assistantId, textChatBot.sessionId);

    //}
    private void Update()
    {
        if (externalInputFieldTest != null)
        {
            if (!String.IsNullOrWhiteSpace(externalInputFieldTest.text))
            {

                sendBtn.interactable = true;
            }
            else
            {
                sendBtn.interactable = false;
            }
        }
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

    public void GetChatResponse(string chatInput)
    {
        StartCoroutine(ProcessChat(chatInput));
    }

    public IEnumerator ProcessChat(string chatInput)
    {

      //if(chatInput.Length<10 && UIManagerScript.instance.userNameType)
      //  {
      //      chatInput = "اسم المستخدم";

      //  }

        //Debug.Log("Processchat: " + chatInput);

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
        
        if (chatInput.Length < 12 && UIManagerScript.instance.userNameType)
        {
            UIManagerScript.instance.userNameSet = true;
            UIManagerScript.instance.userNameType = false;
            userInputName = chatInput;
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

            UIManagerScript.instance.SendMessageServer(userInputName);
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

            UIManagerScript.instance.SendMessageServer(chatInput);
        }

        //var inputMessage = new MessageInput()
        //{

        //    Text = chatInput,
        //    Options = new MessageInputOptions()
        //    {
        //        ReturnContext = true
        //    }
        //};

        
        //Assistant_service.MessageIOS(OnMessageIOS, settings.assistantId, sessionId, input: inputMessage);

        //UIManagerScript.instance.SendMessageServer(chatInput);

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
        loadingPanel.SetActive(false);
        textResponse = response.Result.Output.Generic[0].Text.ToString();
        UIManagerScript.instance.ReciveMessageServer(textResponse);
        messageTested = true;
    }

    protected virtual void OnMessageIOS(DetailedResponse<MyRootClass> response, IBMError error)
    {
        loadingPanel.SetActive(false);
        textResponse = response.Result.output.generic[0].text.ToString();
        UIManagerScript.instance.ReciveMessageServer(textResponse);
       // Debug.Log(textResponse);
        messageTested = true;
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
