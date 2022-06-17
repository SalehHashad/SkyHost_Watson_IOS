using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using RTLTMPro;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayFabAccount : MonoBehaviour
{
    public PlayFabPlayerStats Stat;
    public RTLTextMeshPro namertl;
    public InputField inputPlayerName;
    public GameObject accountPanel;
    public GameObject LeadboardPanel;
    public GameObject UsernamechangePanel;
    public GameObject BadgePanel;
    public int questionnbr=0;
    public int badgenbr = 0;
    public Text Bdgnotf;
    public Sprite[] Badges;
    public Image BadgeProfile;
    public GameObject Bagdeandtxt;
    public int Scene;
    public GameObject Test1;
    public RTLTextMeshPro Badgenumber;
    public RTLTextMeshPro LevelNbr;
    public RTLTextMeshPro CupNbr;
    public RTLTextMeshPro PPonits;
    public GameObject cup1;
    public GameObject cup2;
    public GameObject cup3;
    public GameObject newCup0 , newCup1, newCup2, newCup3;
    public GameObject TextChangeName;

    private void OnEnable()
    {
        TextChangeName.SetActive(false);
        Stat = FindObjectOfType<PlayFabPlayerStats>();
        questionnbr = PlayerPrefs.GetInt("QuestionIndex", 0);
        badgenbr = questionnbr;
        Badgenumber.text = questionnbr.ToString();
        LevelNbr.text= questionnbr.ToString() + "/43";
        PPonits.text = PlayerPrefs.GetInt("score", 0).ToString();
        Debug.Log(badgenbr);
        if (PlayerPrefs.HasKey("Test1Done"))
        {
            Test1.SetActive(false);
        }
        if(badgenbr!=0&& badgenbr >= 14)
        {
            cup1.SetActive(true);
            newCup1.SetActive(true);
            newCup0.SetActive(false);
            newCup2.SetActive(false);
            newCup3.SetActive(false);
            CupNbr.text = "1/3";
        }
        if (badgenbr != 0 && badgenbr >= 28)
        {
            cup2.SetActive(true);
            newCup2.SetActive(true);
            newCup1.SetActive(false);
            newCup0.SetActive(false);
            newCup3.SetActive(false);
            CupNbr.text = "2/3";
        }
        if (badgenbr != 0 && badgenbr >= 43)
        {
            cup3.SetActive(true);
            newCup3.SetActive(true);
            newCup1.SetActive(false);
            newCup0.SetActive(false);
            newCup2.SetActive(false);
            CupNbr.text = "3/3";
        }
    }

    public void UpdatePlayerName()
    {
        // Hole Text aus dem InputFeld
        string text = inputPlayerName.text;

        // Wenn das Textfeld nicht leer ist, dann Spielernamen aktualisieren
        if (text != null)
        {
            // Request erstellen
            var request = new UpdateUserTitleDisplayNameRequest();
            request.DisplayName = text.ToString();
            // API Anfrage
            PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnPlayerNameResult, OnPlayFabError);

        }
    }

    public void ShowBadgepanel()
    {
        BadgePanel.SetActive(true);
    }

    public void hideBadgepanel()
    {
        BadgePanel.SetActive(false);
    }

    public void hidechangepanel()
    {
        UsernamechangePanel.SetActive(false);
    }
    public void ChangePanel()
    {
        if (accountPanel.activeSelf)
        {
            accountPanel.SetActive(false);
        }
        else
        {
            accountPanel.SetActive(true);
            PPonits.text= PlayerPrefs.GetInt("score",0).ToString();


        }

    }

    public void LeaderboardPanel()
    {
        if (LeadboardPanel.activeSelf)
        {
            LeadboardPanel.SetActive(false);
        }
        else
        {
            LeadboardPanel.SetActive(true);
        }
    }

    private void OnPlayFabError(PlayFabError obj)
    {
        print("Error: " + obj.Error);
    }

    private void OnPlayerNameResult(UpdateUserTitleDisplayNameResult obj)
    {
        print("Player name has been updated: " + obj.DisplayName);
        TextChangeName.SetActive(true);
        Invoke("hidechangepanel", 2);
    }

   
    private void Update()
    {
        if (Scene == 1) { 
        namertl.text = inputPlayerName.text;
        questionnbr = PlayerPrefs.GetInt("QuestionIndex", 0) + 1;
        badgenbr = questionnbr;
        Bdgnotf.text = badgenbr.ToString();
        if (badgenbr != 0) {
            Bagdeandtxt.SetActive(true);
          BadgeProfile.sprite = Badges[badgenbr - 1] ;
        }
        //Debug.Log(badgenbr);
        //Debug.Log(PlayerPrefs.GetInt("QuestionIndex", 0));
        }
    }

    public void reload()
    {
        SceneManager.LoadScene("LoginScene");
    }
}