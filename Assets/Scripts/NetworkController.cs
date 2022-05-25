using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using ExtensionLibrary;
using UnityEngine.XR.ARFoundation;
#if UNITY_ANDROID
using UnityEngine.Android;
#endif
#if UNITY_IOS
using UnityEngine.iOS;
#endif

public class NetworkController : MonoBehaviour
{
    public static NetworkController _instance;

    public static Action<bool> internetCallback;

    public GameObject internetConnectionPanel;

    public ARCameraManager cameraManager;

    

    void Start()
    {
        if (_instance == null)
            _instance = this;
        DontDestroyOnLoad(gameObject);
        GetPing();
#if !UNITY_EDITOR
        MicroPhonePermission();
        Invoke("PermissionAccess",2);
#endif
    }

    void PermissionAccess()
    {
#if UNITY_ANDROID

        if (Permission.HasUserAuthorizedPermission(Permission.Microphone) && cameraManager.permissionGranted)
        {
            // The user authorized use of the microphone.
            print("The user authorized use of the microphone.");
            CancelInvoke("PermissionAccess");
        }
        else
        {
            // We do not have permission to use the microphone.
            // Ask for permission or proceed without the functionality enabled.
            Permission.RequestUserPermission(Permission.Microphone);
            print("Ask for permission or proceed without the functionality enabled.");
            Invoke("PermissionAccess", 1);
            PermissionDenyForm();

        }

#elif UNITY_IOS

        if (Application.HasUserAuthorization(UserAuthorization.Microphone) && cameraManager.permissionGranted)
        {
            print("The user authorized use of the microphone.");
            CancelInvoke("PermissionAccess");
        }
        else
        {
            Application.RequestUserAuthorization(UserAuthorization.Microphone);
            print("Ask for permission or proceed without the functionality enabled.");
            PermissionDenyForm();
            //PermissionAccess();
        }

#endif
    }

    void MicroPhonePermission()
    {
#if UNITY_ANDROID

        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            // The user authorized use of the microphone.
            Permission.RequestUserPermission(Permission.Microphone);
            print("Ask for MicroPhonePermission");
            

        }

#elif UNITY_IOS

        if (!Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            Application.RequestUserAuthorization(UserAuthorization.Microphone);
            print("Ask for MicroPhonePermission");
           
        }

#endif
    }

    public void PermissionDenyForm()
    {

        UIManagerScript.instance.permissionPanel.SetActive(true);

    }

    public void GetPing()
    {
        StartCoroutine(CheckInternet(internetCallback));
        Debug.Log("Checking Internet..".Colored(Color.red));
    }
    private void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Check your internet Connection!!!!!!!".Colored(Color.magenta));
            if (!internetConnectionPanel.activeSelf)
            {
                GetPing();
            }
        }
    }

    public void Destroy()
    {
        DestroyImmediate(gameObject);
    }

    IEnumerator CheckInternet(Action<bool> callback)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://www.google.com");
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("No Internet..".Colored(Color.magenta) + www.error);
            internetCallback?.Invoke(false);
            internetConnectionPanel.SetActive(true);
            GetPing();

        }
        else
        {
            Debug.Log("Internet connected..".Colored(Color.green));
            internetCallback?.Invoke(true);
            internetConnectionPanel.SetActive(false);
        }
    }
}
