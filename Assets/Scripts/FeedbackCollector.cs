////////////////////////////////////////
//
//      Collecting Feedback
//      by Matthew Ventures
//    mrventures.net/gamedevlearn
//
////////////////////////////////////////

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using RTLTMPro;

public class FeedbackCollector : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI txtData;
    [SerializeField] private UnityEngine.UI.Button btnSubmit;
    [SerializeField] private CollectionOption option;
    public RTLTextMeshPro Name;
    public RTLTextMeshPro email;
    public RTLTextMeshPro Message;
    public string _name;
    public string _email;
    public string _Message;
    private enum CollectionOption { openEmailClient, openGFormLink, sendGFormData };

    private const string kReceiverEmailAddress = "me@gmail.com";

    private const string kGFormBaseURL = "https://docs.google.com/forms/d/1fd0UVwNqv7_VE9vD4_h0IJFBRpnggXc5qQXjzSf6qY8/";
    private const string kGFormEntryID = "entry.2005620554";
    private const string kGFormEntryID2 = "entry.1045781291";
    private const string kGFormEntryID3 = "entry.839337160";
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(txtData);
        UnityEngine.Assertions.Assert.IsNotNull(btnSubmit);
        btnSubmit.onClick.AddListener(delegate {
            switch (option)
            {
                case CollectionOption.openEmailClient:
                    OpenEmailClient();
                    break;
                case CollectionOption.openGFormLink:
                    OpenGFormLink();
                    break;
                case CollectionOption.sendGFormData:
                    StartCoroutine(SendGFormData(_name,_email,_Message));
                    break;
            }
        });
    }

    public static void OpenEmailClient()
    {
        string email = "fateenappsaudia@gmail.com";
        string subject = "مساعدة من تطبيق فطين";
        string body = "";
        OpenLink("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }

    private static void OpenGFormLink()
    {
        string urlGFormView = kGFormBaseURL + "viewform";
        OpenLink(urlGFormView);
    }
    private void Update()
    {
        _name = Name.text;
        _email = email.text;
        _Message = Message.text;
    }
    
    public void sendata()
    {
        StartCoroutine(SendGFormData(_name, _email, _Message));
    }
    private static IEnumerator SendGFormData(string _name,string _email,string _Message)
    {
        //bool isString = dataContainer is string;
        //string jsonData = isString ? dataContainer.ToString() : JsonUtility.ToJson(dataContainer);
        
        WWWForm form = new WWWForm();
        form.AddField(kGFormEntryID, _name);
        form.AddField(kGFormEntryID2, _email);
        form.AddField(kGFormEntryID3, _Message);
        string urlGFormResponse = kGFormBaseURL + "formResponse";
        using (UnityWebRequest www = UnityWebRequest.Post(urlGFormResponse, form))
        {
            yield return www.SendWebRequest();
        }
    }

    // We cannot have spaces in links for iOS
    public static void OpenLink(string link)
    {
        bool googleSearch = link.Contains("google.com/search");
        string linkNoSpaces = link.Replace(" ", googleSearch ? "+" : "%20");
        Application.OpenURL(linkNoSpaces);
    }
}


