using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using RTLTMPro;

public class PlayFabLoginScript : MonoBehaviour
{
    public string _TitleId;
    public InputField regUsername, regEmail, regPassword;
   // public tp
    public GameObject regPanel;
    public InputField loginUsername, loginPassword;
    public GameObject loginPanel;
    public GameObject userInputPanel;

    public GameObject infoPanel;
    public GameObject ResetPasswordPanel;
    public Text requestedEmail;
    public Text infoUsername, infoCreatedAt;
    public RTLTextMeshPro errorText;
    public GameObject AccountStatu;
    public RTLTextMeshPro AfficheName;

    // Use this for initialization
    void Start()
    {
        AccountStatu.SetActive(false);
        if (PlayerPrefs.HasKey("UserName"))
        {
            loginUsername.text = PlayerPrefs.GetString("UserName");
            loginPassword.text=PlayerPrefs.GetString("Password");
            AutoLogin();
        }
    }

    public void CheckAccount()
    {
        if (PlayerPrefs.GetInt("ActiveAcount") == 0)
        {
            AccountStatu.SetActive(true);
        }
    }
    private void OnLoginSuccess(LoginResult obj)
    {
        Debug.Log("API call worked! :-)");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Registrierung
    public void Register()
    {
        var request = new RegisterPlayFabUserRequest();
        request.TitleId = PlayFabSettings.TitleId;
        // Eingabedaten zuweisen
        request.Email = regEmail.text;
        request.Username = regUsername.text;
        request.Password = regPassword.text;

        // Übergabe des Registrierungs-Request an PlayFab API
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterResult, OnPlayFabError);
    }

    private void OnPlayFabError(PlayFabError obj)
    {
        //print("Registrierung fehlgeschlagen!");
        print("Error: " + obj.Error);
        //errorText.text = obj.Error.ToString();

        string output = "";

        switch (obj.Error)
        {
            case PlayFabErrorCode.AccountBanned:
                output = "تم حظر الحساب الخاص بك";
                break;
            case PlayFabErrorCode.EmailAddressNotAvailable:
                output = "تم التسجيل بهذا البريد من قبل";
                break;
            case PlayFabErrorCode.InvalidParams:
                output = "يرجى ملء جميع الخانات";
                break;
            case PlayFabErrorCode.InvalidUsernameOrPassword:
                output = "اسم المستخدم أو كلمة المرور خاطئة";
                break;
            case PlayFabErrorCode.UsernameNotAvailable:
                output = "يرجى اختيار اسم مستخدم مختلف";
                break;
            case PlayFabErrorCode.AccountNotFound:
                output = "حساب المستخدم غير موجود!";
                break;
            default:
                break;
        }

        // Text der Fehlermeldung zuweisen
        errorText.text = output;
        Invoke("Hideerror", 2.0f);
    }
    public void Hideerror()
    {
        errorText.text = "";
    }
    private void OnRegisterResult(RegisterPlayFabUserResult obj)
    {
        print("Registration successful!");
        PlayerPrefs.SetString("UserName", regUsername.text);
        PlayerPrefs.SetString("Password", regPassword.text);
        LoginAfterSignUp();
        // Panel Register ausblenden
        userInputPanel.SetActive(false);
    }
    public void LoginAfterSignUp()
    {
        var request = new LoginWithPlayFabRequest();
        request.TitleId = PlayFabSettings.TitleId;
        request.Username = PlayerPrefs.GetString("UserName");
        request.Password = PlayerPrefs.GetString("Password");

        // Request an PlayFab API übergeben
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginResultAfterSignup, OnPlayFabError);
    }
    public void AutoLogin()
    {
        var request = new LoginWithPlayFabRequest();
        request.TitleId = PlayFabSettings.TitleId;
        request.Username = PlayerPrefs.GetString("UserName");
        request.Password = PlayerPrefs.GetString("Password");

        // Request an PlayFab API übergeben
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginResult, OnPlayFabError);
    }
    public void Login()
    {
        var request = new LoginWithPlayFabRequest();
        request.TitleId = PlayFabSettings.TitleId;
        request.Username = loginUsername.text;
        request.Password = loginPassword.text;

        // Request an PlayFab API übergeben
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginResult, OnPlayFabError);
    }

    private void OnLoginResult(LoginResult obj)
    {
        PlayerPrefs.SetString("UserName", loginUsername.text);
        PlayerPrefs.SetString("Password", loginPassword.text);
        print("Login successful!");
        // Login Panel deaktivieren
        userInputPanel.SetActive(false);
        // Account Informationen holen - Methode starten
        GetStats();
        GetStatsLast();
        GetAccountInfo();
    }
    private void OnLoginResultAfterSignup(LoginResult obj)
    {
        print("Login successful!");
        // Login Panel deaktivieren
        userInputPanel.SetActive(false);
        // Account Informationen holen - Methode starten
        SaveStats();
        GetAccountInfo();
    }
    public void SaveStats()
    {
        // Neue Anfrage erstellen
        var request = new UpdatePlayerStatisticsRequest();
        // Liste mit Statistiken
        request.Statistics = new List<StatisticUpdate>();
        // Neuen Wert für Statistik anlegen
        var stat = new StatisticUpdate { StatisticName = "Active", Value = 0 };
        // Eintrag hinzufügen
        request.Statistics.Add(stat);
        // Anfrage an PlayFab API starten
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSetStatsSuccess, OnPlayFabError);

    }
    private void OnSetStatsSuccess(UpdatePlayerStatisticsResult obj)
    {
        print("New stats saved");
        GetStats();
        GetStatsLast();
    }
    // Account Informationen
    public void GetAccountInfo()
    {
        var request = new GetAccountInfoRequest();
        // Request an API übergeben
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccountInfoSuccess, OnPlayFabError);
    }
    public void GetStats()
    {
        // Neue Anfrage erstellen
        var request = new GetPlayerStatisticsRequest();
        request.StatisticNames = new List<string>() { "Active" };
        // Übergabe an PlayFab API
        PlayFabClientAPI.GetPlayerStatistics(request, GetStatsSuccess, OnPlayFabError);
    }
    public void GetStatsLast()
    {
        // Neue Anfrage erstellen
        var request = new GetPlayerStatisticsRequest();
        request.StatisticNames = new List<string>() { "LastTest" };
        // Übergabe an PlayFab API
        PlayFabClientAPI.GetPlayerStatistics(request, GetStatsSuccesslast, OnPlayFabError);
    }

    private void GetStatsSuccess(GetPlayerStatisticsResult obj)
    {
        print("Stats were received successfully");

        // Statistiken ausgeben
        foreach (var stat in obj.Statistics)
        {
            print("Statistic: " + stat.StatisticName + " Wert: " + stat.Value);
            PlayerPrefs.SetInt("ActiveAcount", stat.Value);
        }
    }
    private void GetStatsSuccesslast(GetPlayerStatisticsResult obj)
    {
        print("Stats were received successfully");

        // Statistiken ausgeben
        foreach (var stat in obj.Statistics)
        {
            print("Statistic: " + stat.StatisticName + " Wert: " + stat.Value);
            PlayerPrefs.SetInt("LastTest", stat.Value);
        }
    }
    private void OnGetAccountInfoSuccess(GetAccountInfoResult resultData)
    {
        // Info Panel eingeblendet? falls nein => einblenden
        if (PlayerPrefs.GetInt("ActiveAcount") != 0) { 
        if (!infoPanel.activeSelf)
        {
            infoPanel.SetActive(true);
        }

        print("Account data received");
        // Daten ausgeben lassen
        print(resultData.AccountInfo.Username);
        // Ergebnis auf Textfeld anzeigen
        infoUsername.text = resultData.AccountInfo.Username.ToString();
        //infoCreatedAt.text = resultData.AccountInfo.Created.ToString();
        infoCreatedAt.text = resultData.AccountInfo.PrivateInfo.Email.ToString();
        AfficheName.text = resultData.AccountInfo.TitleInfo.DisplayName.ToString();
        print(resultData.AccountInfo.Created);
        }
        else
        {
            AccountStatu.SetActive(true);
        }
    }
    public void ChangePasswordResetPanel()
    {
        if (ResetPasswordPanel.activeSelf)
        {
            ResetPasswordPanel.SetActive(false);
        }
        else
        {
            ResetPasswordPanel.SetActive(true);
        }
    }
    public void RequestPassword()
    {
        string text = requestedEmail.text;
        if (text != "")
        {
            var request = new SendAccountRecoveryEmailRequest();
            request.Email = text;
            request.TitleId = _TitleId;
            PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoveryEmailSuccess, OnPlayFabError);
        }
    }

    private void OnRecoveryEmailSuccess(SendAccountRecoveryEmailResult obj)
    {
        print("Your Password in the reset Progress, check your email");
    }

    void SetUserData()
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>() {
            {"Ancestor", "Arthur"},
            {"Successor", "Fred"}
        }
        },
        result => Debug.Log("Successfully updated user data"),
        error => {
            Debug.Log("Got error setting user data Ancestor to Arthur");
            Debug.Log(error.GenerateErrorReport());
        });
    }

    void GetUserData(string myPlayFabeId)
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myPlayFabeId,
            Keys = null
        }, result => {
            Debug.Log("Got user data:");
            if (result.Data == null || !result.Data.ContainsKey("Ancestor")) Debug.Log("No Ancestor");
            else Debug.Log("Ancestor: " + result.Data["Ancestor"].Value);
        }, (error) => {
            Debug.Log("Got error retrieving user data:");
            Debug.Log(error.GenerateErrorReport());
        });
    }

}