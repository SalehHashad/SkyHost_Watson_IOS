using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
using TMPro;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class QuestionManager : MonoBehaviour
{
    public GameObject TryagainPanel;
    public int IndexQ;
    public int IndexR;
    public GameObject[] QuesionsP;
    public Texture[] Headers;
    public RawImage HeaderRaw;
    public GameObject headerpanel;
    public GameObject[] AllQpanel;
    public GameObject ActiveQpanel;
    public int Tries = 0;
    public int reward = 0;
    public int categories = 0;
    public GameObject FinishQuestionPanel;
    public RTLTextMeshPro arabictext;
    public float purcentf;
    public PlayFabPlayerStats SaveStat;
    public string lvl;
    public int lvvl;
    public Vector3 InitialPosP;
    bool restart = false;
    // Start is called before the first frame update
    void Start()
    {
        
        SaveStat = GetComponent<PlayFabPlayerStats>();
        FinishQuestionPanel.SetActive(false);
        //PlayerPrefs.SetInt("QuestionIndex",1);
        IndexR= PlayerPrefs.GetInt("ResponseIndex", 0);
        IndexQ =  PlayerPrefs.GetInt("QuestionIndex",0);
        //Fetch the RawImage component from the GameObject
        HeaderRaw = headerpanel.GetComponent<RawImage>();
        //Change the Texture to be the one 
        HeaderRaw.texture = Headers[IndexQ];
        InitialPosP = QuesionsP[IndexQ].transform.position;
        for (int i = 0; i < QuesionsP.Length; i++)
        {
            if (QuesionsP[i] == QuesionsP[IndexQ])
            {
              //QuesionsP[i].transform.position = InitialPosP;
                
                QuesionsP[i].SetActive(true);
            }
            else
            {
                QuesionsP[i].transform.position = new Vector3(3000f, transform.position.y, transform.position.z);
                QuesionsP[i].SetActive(false);
            }
        }
        ActiveQpanel = AllQpanel[IndexQ];

    }

   void ShowRightPAnel() 
    {
        IndexQ = PlayerPrefs.GetInt("QuestionIndex", 0);
        //Fetch the RawImage component from the GameObject
        HeaderRaw = headerpanel.GetComponent<RawImage>();
        //Change the Texture to be the one 
        HeaderRaw.texture = Headers[IndexQ];
        for (int i = 0; i < QuesionsP.Length; i++)
        {
            if (QuesionsP[i] == QuesionsP[IndexQ])
            {
            // QuesionsP[i].transform.position = InitialPosP;

                QuesionsP[i].SetActive(true);
            }
            else
            {
                QuesionsP[i].transform.position = new Vector3(3000f, transform.position.y, transform.position.z);
                QuesionsP[i].SetActive(false);
            }
        }
        ActiveQpanel = AllQpanel[IndexQ];
    }
    public void getpurcent()
    {
        purcentf= ActiveQpanel.GetComponent<DataPanelQ>().purcentageof;
    }
    public void NextQuestion()
    {
        Tries++;
        float purcent = ActiveQpanel.GetComponent<DataPanelQ>().purcentageof;
        if (Tries == 1)
        {
            if (purcent == 100)
            {
                reward = reward + 60;
                //show panel great
                FinishQuestionPanel.SetActive(true);
                arabictext.text = "أحسنت لقد ربحت 60 ";
                IndexQ = IndexQ + 1;
                if (!restart)
                {
                    PlayerPrefs.SetInt("ResponseIndex", IndexQ);
                    SaveStats(reward);
                    SaveStatsQ(lvl, 1);
                }
                //PlayerPrefs.SetInt("ResponseIndex", IndexQ);
                PlayerPrefs.SetInt("QuestionIndex", IndexQ);
              
                ActiveQpanel.GetComponent<DataPanelQ>().resetnumberdata();
                Tries = 0;
                

            }
            if (purcent >= 80 && purcent <= 99)
            {
                TryagainPanel.SetActive(true);
                Invoke("HideTryAgainPanel", 2f);
                // placenumber
                if (!restart)
                {
                    SaveStatsQ(lvl, 1);
                    //PlayerPrefs.SetInt("ResponseIndex", IndexQ);
                    //SaveStats(reward);
                    //SaveStatsQ(lvl, 1);
                }
                
                categories = 2;
                ActiveQpanel.GetComponent<DataPanelQ>().PlaceNumber();
            }
            if (purcent >= 50 && purcent <= 79)
            {
                TryagainPanel.SetActive(true);
                Invoke("HideTryAgainPanel", 2f);
                //placenumber
                string levl = "Q" + (IndexQ + 1).ToString();
                if (!restart)
                {
                    SaveStatsQ(lvl, 1);
                    //PlayerPrefs.SetInt("ResponseIndex", IndexQ);
                    //SaveStats(reward);
                    //SaveStatsQ(lvl, 1);
                }
                categories = 3;
                ActiveQpanel.GetComponent<DataPanelQ>().PlaceNumber();
            }
            if (purcent < 50 )
            {
                TryagainPanel.SetActive(true);
                Invoke("HideTryAgainPanel", 2f);
                //FinishQuestionPanel.SetActive(true);
                //arabictext.text = "أعد المحاولة";
                if (!restart)
                {
                    SaveStatsQ(lvl, 1);
                    //PlayerPrefs.SetInt("ResponseIndex", IndexQ);
                    //SaveStats(reward);
                    //SaveStatsQ(lvl, 1);
                }
                ActiveQpanel.GetComponent<DataPanelQ>().resetnumberdata();
                Tries = 0;
               // PlayerPrefs.SetInt("QuestionIndex", 0);

            }
        }
        if (Tries == 2)
        {
            if (purcent == 100&& categories == 2)
            {
                reward = 45;
                //SaveStats(reward);
                //show panel great
                FinishQuestionPanel.SetActive(true);
                arabictext.text = "أحسنت لقد ربحت 45 ";
                IndexQ = IndexQ + 1;
                PlayerPrefs.SetInt("QuestionIndex", IndexQ);
                if (!restart)
                {
                    PlayerPrefs.SetInt("ResponseIndex", IndexQ);
                    SaveStats(reward);
                    //SaveStatsQ(lvl, 1);
                }
                ActiveQpanel.GetComponent<DataPanelQ>().resetnumberdata();
                Tries = 0;
                categories = 0;
            }
            if (purcent == 100 && categories == 3)
            {
                reward = 24;
                
                //show panel great
                FinishQuestionPanel.SetActive(true);
                arabictext.text = "أحسنت لقد ربحت 24 ";
                IndexQ = IndexQ + 1;
                if (!restart)
                {
                    PlayerPrefs.SetInt("ResponseIndex", IndexQ);
                    SaveStats(reward);
                    SaveStatsQ(lvl, 1);
                }
                PlayerPrefs.SetInt("QuestionIndex", IndexQ);
                
                Tries = 0;
                categories = 0;
               
            }
            if(purcent >= 0 && purcent <= 99 && categories == 2|| purcent >= 0 && purcent <= 99 && categories == 3)
            {
                //rest number
                
                FinishQuestionPanel.SetActive(true);
                arabictext.text = "أعد المحاولة";
                ActiveQpanel.GetComponent<DataPanelQ>().resetnumberdata();
                if (!restart)
                {
                    SaveStatsQ(lvl, 1);
                }
               // SaveStatsQ(lvl, 1);
                Tries = 0;
                categories = 0;
                PlayerPrefs.SetInt("QuestionIndex", 0);
                //eloadscene();
            }
            IndexQ = PlayerPrefs.GetInt("QuestionIndex", 0);
            if (IndexQ == 44)
            {
                FinishQuestionPanel.SetActive(true);
                arabictext.text = "في إنتظار التقيم";
            }
        }
        //if (purcent == 100)
        //{
        //    if (Tries == 1)
        //    {
        //        reward = reward + 60;
        //        //show panel great
        //        FinishQuestionPanel.SetActive(true);
        //        arabictext.text = "أحسنت لقد ربحت 60 ";
        //        IndexQ = IndexQ + 1;
        //        PlayerPrefs.SetInt("QuestionIndex", IndexQ);
        //        Tries = 0;

        //    }
        //    if (Tries == 2&& categories == 1)
        //    {
        //        reward = reward + 30;
        //        //show panel great
        //        arabictext.text = "أحسنت لقد ربحت 30 ";
        //        FinishQuestionPanel.SetActive(true);
        //        IndexQ = IndexQ + 1;
        //        PlayerPrefs.SetInt("QuestionIndex", IndexQ);
        //        Tries = 0;
        //    }
        //    //ActiveQpanel.GetComponent<DataPanelQ>().PlaceNumber();
        //}
        
        //if (purcent >= 80 && purcent <= 99)
        //{
        //    if (Tries == 1)
        //    {
        //        reward = reward + 45;
        //        //show panel great
        //        FinishQuestionPanel.SetActive(true);
        //        arabictext.text = "أحسنت لقد ربحت 45 ";
        //    }
        //    if (Tries == 2 && categories == 2)
        //    {
        //        //show panel great
        //        FinishQuestionPanel.SetActive(true);
        //        arabictext.text = "أحسنت لقد ربحت 30 ";
        //        reward = reward + 30;
        //    }
        //    if (Tries == 3 && categories == 2)
        //    {
        //        //Replay panel
        //        FinishQuestionPanel.SetActive(true);
        //        arabictext.text = "أعد المحاولة";
        //        ActiveQpanel.GetComponent<DataPanelQ>().resetnumberdata();
        //    }

        //    //ActiveQpanel.GetComponent<DataPanelQ>().PlaceNumber();
        //}
        //if (purcent >= 50 && purcent <= 79)
        //{
        //    if (Tries == 1)
        //    {
        //        reward = reward + 45;
        //        //show panel great
        //        FinishQuestionPanel.SetActive(true);
        //        arabictext.text = "أحسنت لقد ربحت 45 ";
        //    }
        //    if (Tries == 2 && categories == 3)
        //    {
        //        //show panel great
        //        FinishQuestionPanel.SetActive(true);
        //        arabictext.text = "أحسنت لقد ربحت 30 ";
        //        reward = reward + 30;
        //    }
        //    if (Tries == 3 && categories == 3)
        //    {
        //        //Replay panel
        //        FinishQuestionPanel.SetActive(true);
        //        arabictext.text = "أعد المحاولة";
        //        ActiveQpanel.GetComponent<DataPanelQ>().resetnumberdata();
        //    }

        //    //ActiveQpanel.GetComponent<DataPanelQ>().PlaceNumber();
        //}
        //if (purcent < 50 && categories== 4)
        //{
        //    //Replay panel
        //    FinishQuestionPanel.SetActive(true);
        //    arabictext.text = "أعد المحاولة";
        //    ActiveQpanel.GetComponent<DataPanelQ>().resetnumberdata();
        //    reloadscene();
        //}
        //if (purcent > 1000)
        //{
           
        //}
    }

    public void HideTryAgainPanel()
    {
        TryagainPanel.SetActive(false);
    }
    public void reloadscene()
    {
        SceneManager.LoadScene("Gamification");
    }

    public void nextQuestionP()
    {
        IndexQ = PlayerPrefs.GetInt("QuestionIndex", 0) + 1;
        if (IndexQ == 44)
        {
            FinishQuestionPanel.SetActive(true);
            arabictext.text = "في إنتظار التقيم";
            SaveStatsLastTest();
        }
        if(IndexQ < 44) { 
        PlayerPrefs.SetInt("QuestionIndex", IndexQ);
        Tries = 0;
        HeaderRaw.texture = Headers[IndexQ];
        for (int i = 0; i < QuesionsP.Length; i++)
        {
            if (QuesionsP[i] == QuesionsP[IndexQ])
            {
                QuesionsP[i].SetActive(true);
            }
            else
            {
                QuesionsP[i].SetActive(false);
            }
        }
        }

    }
    // Update is called once per frame
    void Update()
    {
        ShowRightPAnel();
       
        lvvl = IndexQ + 1;
        lvl = "Q" + lvvl;
        if(PlayerPrefs.GetInt("ResponseIndex", 0)!= PlayerPrefs.GetInt("QuestionIndex", 0))
        {
            restart = true;
        }
        else
        {
            restart = false;
        }
        
    }

    public void SaveStats(int value)
    {
        // Neue Anfrage erstellen
        var request = new UpdatePlayerStatisticsRequest();
        // Liste mit Statistiken
        request.Statistics = new List<StatisticUpdate>();
        // Neuen Wert für Statistik anlegen
        var stat = new StatisticUpdate { StatisticName = "Coin", Value = value };
        // Eintrag hinzufügen
        request.Statistics.Add(stat);
        // Anfrage an PlayFab API starten
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSetStatsSuccess, OnPlayFabError);

    }
    public void SaveStatsQ(String Qnumber, int value)
    {
        // Neue Anfrage erstellen
        var request = new UpdatePlayerStatisticsRequest();
        // Liste mit Statistiken
        request.Statistics = new List<StatisticUpdate>();
        // Neuen Wert für Statistik anlegen
        var stat = new StatisticUpdate { StatisticName = Qnumber, Value = value };
        // Eintrag hinzufügen
        request.Statistics.Add(stat);
        // Anfrage an PlayFab API starten
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSetStatsSuccess, OnPlayFabError);

    }
    public void SaveStatsLastTest()
    {
        // Neue Anfrage erstellen
        var request = new UpdatePlayerStatisticsRequest();
        // Liste mit Statistiken
        request.Statistics = new List<StatisticUpdate>();
        // Neuen Wert für Statistik anlegen
        var stat = new StatisticUpdate { StatisticName = "LastTest", Value = 0 };
        // Eintrag hinzufügen
        request.Statistics.Add(stat);
        // Anfrage an PlayFab API starten
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSetStatsSuccess, OnPlayFabError);

    }

    public void GetStats()
    {
        // Neue Anfrage erstellen
        var request = new GetPlayerStatisticsRequest();
        request.StatisticNames = new List<string>() { "Coin" };
        // Übergabe an PlayFab API
        PlayFabClientAPI.GetPlayerStatistics(request, GetStatsSuccess, OnPlayFabError);

    }

    private void GetStatsSuccess(GetPlayerStatisticsResult obj)
    {
        print("Stats were received successfully");

        // Statistiken ausgeben
        foreach (var stat in obj.Statistics)
        {
            print("Statistic: " + stat.StatisticName + "Coin" + stat.Value);
            PlayerPrefs.SetInt("score", stat.Value);
        }
    }

    private void OnPlayFabError(PlayFabError obj)
    {
        print("Something went wrong in the stats script");
    }

    private void OnSetStatsSuccess(UpdatePlayerStatisticsResult obj)
    {
        print("New stats saved");
        GetStats();
    }
}
