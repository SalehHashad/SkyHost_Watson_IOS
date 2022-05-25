using DG.Tweening;
using TMPro;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript instance;

    public GameObject introScreen1;
    public GameObject introScreen2;
    public GameObject areaScanScreen;
    public GameObject scanScreen;
    public Button scanBtn;
    public GameObject homeScreen;
    public GameObject sidePanelParent;
    public GameObject sidePanel;
    public GameObject aboutUsPanel;
    public GameObject termsPanel;
    public GameObject privacyPanel;
    public GameObject useAppPanel;
    public GameObject audioChatPanel;
    public GameObject textChatPanel;
    public GameObject permissionPanel;
    public bool planeDetected = true;
    public InputManagerScript inputManager;

    [Space]
    [Header("Chat UI Components")]
    public GameObject textChatt;
    public ScrollRect scrollRect;
    public GameObject prefabSend;
    public GameObject prefabReceive;
    public GameObject videoLinkBtn;
    public Transform parent;
    public float startingPos = 0;
    public GameObject serverConnectionPanelTextChat;
    [SerializeField] private TMP_InputField inputFieldTest;

    [Space]
    [Header("Audio Chat Components")]
    public GameObject audioChat;
    public GameObject audioListingBtn;
    public bool ARBotEnabled;

    [SerializeField]
    bool video;
        public bool userNameType, userNameSet;
    [SerializeField]
    string[] arr;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        CloseAllPanels();
        homeScreen.SetActive(true);
       // introScreen1.SetActive(true);
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    private void Update()
    {
#if !UNITY_EDITOR
        if (inputManager.arPlaneManager.trackables.count >= 1 && !planeDetected)
        {
            print(" Plane detected "+ inputManager.arPlaneManager.trackables.count);
            planeDetected = true;
            CloseAllPanels();
            scanScreen.SetActive(true);
        }
#endif
    }

    public void OnIntroScreenNextClick(int number)
    {
        if (number == 1)
        {
            CloseAllPanels();
            introScreen2.SetActive(true);
        }
        else
        {
            CloseAllPanels();
            
            homeScreen.SetActive(true);

        }
    }

    public async void OnScanClick()
    {
        scanBtn.interactable = false;
#if !UNITY_EDITOR
        await inputManager.PlaceARBot();
#endif

        CloseAllPanels();

        audioChat.SetActive(true);
        audioChatPanel.SetActive(true);

    }

    public void OnAudioChatClick()
    {
        CloseAllPanels();
        if(!ARBotEnabled)
        {
            ARBotEnabled = true;
        planeDetected = false;
#if !UNITY_EDITOR
            areaScanScreen.SetActive(true);
#elif UNITY_EDITOR
        scanScreen.SetActive(true);
#endif
        }
        else
        {
            audioChat.SetActive(true);
            audioChatPanel.SetActive(true);
        }

    }



    public void OnTextChatClick()
    {
        CloseAllPanels();
        textChatt.SetActive(true);
        textChatPanel.SetActive(true);
    }

    public void OpenSidePanel()
    {
        CloseAllPanels();
        sidePanelParent.SetActive(true);
        sidePanel.SetActive(true);
    }

    public void CloseSidePanel()
    {
        sidePanelParent.SetActive(false);
        sidePanel.SetActive(false);
    }

    public void OnDiscriptivePanelClick(string str)
    {
        switch (str)
        {
            case "AboutUS":
                aboutUsPanel.SetActive(true);
                break;
            case "TermsPanel":
                termsPanel.SetActive(true);
                break;
            case "PrivacyPanel":
                privacyPanel.SetActive(true);
                break;
            case "RateUs":
                print("Rate US.....");
                break;
            case "UseApp":
                useAppPanel.SetActive(true);
                break;
        }
    }

    public void OnHomeClick()
    {
        
        CloseAllPanels();
         audioChat.SetActive(false);
        homeScreen.SetActive(true);
        SceneManager.LoadScene("LoginScene");
    }

    void CloseAllPanels()
    {
        introScreen1.SetActive(false);
        introScreen2.SetActive(false);
        areaScanScreen.SetActive(false);
        scanScreen.SetActive(false);
        homeScreen.SetActive(false);
        sidePanelParent.SetActive(false);
        sidePanel.SetActive(false);
        aboutUsPanel.SetActive(false);
        termsPanel.SetActive(false);
        privacyPanel.SetActive(false);
        useAppPanel.SetActive(false);
        audioChatPanel.SetActive(false);
        textChatPanel.SetActive(false);
    }


    public void SendMessageServer(string str)
    {
        GameObject obj = Instantiate(prefabSend, new Vector3(0, 0, 0), Quaternion.identity, parent);
   
        //   اسم المستخدم
        InsertMessageChatBox(str, obj.GetComponentInChildren<RTLTextMeshPro>());
        //obj.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);

        SizeUpUI(str, obj);
        obj.transform.localPosition = new Vector3(0, startingPos, 0);
        startingPos -= obj.GetComponent<RectTransform>().rect.height + 25;
        inputFieldTest.text = null;
        ScrollUIUp();
    }

    public void ReciveMessageServer(string str)
    {
        if(!userNameSet)
        {
        userNameType = true;
        }

        if (str.Contains("*name"))
        {
            str = str.Replace("*name", TextChatBot.userInputName);
            print(str);
        }

        if (str.Contains("http"))
        {
            arr = str.Split('<');
            print(arr[1]);

            GameObject objVideo = Instantiate(prefabReceive, new Vector3(0, 0, 0), Quaternion.identity, parent);

            InsertMessageChatBox(arr[0], objVideo.GetComponentInChildren<RTLTextMeshPro>());
            //objVideo.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);

            SizeUpUI(arr[0], objVideo);
            objVideo.transform.localPosition = new Vector3(0, startingPos, 0);
            startingPos -= objVideo.GetComponent<RectTransform>().rect.height + 25;
            inputFieldTest.text = null;
            ScrollUIUp();
            InsertVideo(arr[1]);
        }
        else
        {
            GameObject obj = Instantiate(prefabReceive, new Vector3(0, 0, 0), Quaternion.identity, parent);
            InsertMessageChatBox(str, obj.GetComponentInChildren<RTLTextMeshPro>());
            //obj.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
            SizeUpUI(str, obj);
            obj.transform.localPosition = new Vector3(0, startingPos, 0);
            startingPos -= obj.GetComponent<RectTransform>().rect.height + 25;
            inputFieldTest.text = null;
            ScrollUIUp();
        }

    }

    void InsertVideo(string str)
    {
        GameObject obj = Instantiate(videoLinkBtn, new Vector3(0, 0, 0), Quaternion.identity, parent);
        obj.GetComponent<Button>().onClick.AddListener(delegate { print("Cliked"); Application.OpenURL(str); });
        obj.GetComponent<RectTransform>().sizeDelta = new Vector2(obj.GetComponent<RectTransform>().rect.width, 150);
        obj.transform.localPosition = new Vector3(0, startingPos, 0);
        startingPos -= obj.GetComponent<RectTransform>().rect.height + 25;
        inputFieldTest.text = null;
        ScrollUIUp();
    }


    void InsertMessageChatBox(string str, RTLTextMeshPro textField)
    {
        textField.text = str;
    }

    void ScrollUIUp()
    {
        scrollRect.DOVerticalNormalizedPos(0, .5f).SetDelay(.5f);
    }


    void SizeUpUI(string str, GameObject obj)
    {
        int stringLength = str.Length;

        if (str.Length > 100)
        {
            obj.GetComponent<RectTransform>().sizeDelta = new Vector2(obj.GetComponent<RectTransform>().rect.width, 650);
        }
        else
        {
            obj.GetComponent<RectTransform>().sizeDelta = new Vector2(obj.GetComponent<RectTransform>().rect.width, 250 + (110 * (stringLength / 25)));
            //obj.GetComponent<RectTransform>().sizeDelta = new Vector2(obj.GetComponent<RectTransform>().rect.width, 500);
            obj.GetComponent<ScrollRect>().enabled = false;
        }
    }
}
