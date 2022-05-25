using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab.ClientModels;
using PlayFab;

public class Finalpanelscript : MonoBehaviour
{
    public Text OldScoreScore;
    public Text PurcentageofthisQuestion;
    public Text RestOfQuestion;
    public QuestionManager qManager;
    public GameObject ThisPanel;
    public Slider Slder;
    public float val;
    public Sprite[] Badge;
    public Image BadgeAnimated;
    public Sprite[] Cup;
    public Image CupAnimated;
    public GameObject CupGameobject;
    // Start is called before the first frame update
    void OnEnable()
    {
        if(PlayerPrefs.GetInt("QuestionIndex", 0)== PlayerPrefs.GetInt("ResponseIndex", 0))
        {
            SaveStats(PlayerPrefs.GetInt("QuestionIndex", 0) + 1);
        }
        
        ThisPanel = this.gameObject;
        int idx = PlayerPrefs.GetInt("QuestionIndex", 0);
        BadgeAnimated.sprite = Badge[idx];
        if (idx == 14)
        {
            CupGameobject.SetActive(true);
            CupAnimated.sprite = Cup[0];
        }
        if (idx == 28)
        {
            CupGameobject.SetActive(true);
            CupAnimated.sprite = Cup[1];
        }
        if (idx == 43)
        {
            CupGameobject.SetActive(true);
            CupAnimated.sprite = Cup[2];
        }
        int currentquestion =PlayerPrefs.GetInt("QuestionIndex", 0)+1;
        val =  (float)currentquestion/(float)43;
        Slder.value = val;
        RestOfQuestion.text = "43/" + currentquestion.ToString();
        qManager.getpurcent();
        PurcentageofthisQuestion.text = "%" + qManager.purcentf.ToString();
        qManager.GetStats();
        
        
    }
    
    public void hidePanel()
    {
        ThisPanel.SetActive(false);
        if (qManager.Tries == 0)
        {
            SceneManager.LoadScene("Gamification");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int scoreee = PlayerPrefs.GetInt("score", 0);
        
        OldScoreScore.text = scoreee.ToString(); 
    }
    public void SaveStats(int value)
    {
        // Neue Anfrage erstellen
        var request = new UpdatePlayerStatisticsRequest();
        // Liste mit Statistiken
        request.Statistics = new List<StatisticUpdate>();
        // Neuen Wert für Statistik anlegen
        var stat = new StatisticUpdate { StatisticName = "Levels", Value = value };
        // Eintrag hinzufügen
        request.Statistics.Add(stat);
        // Anfrage an PlayFab API starten
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSetStatsSuccess, OnPlayFabError);

    }
    private void OnSetStatsSuccess(UpdatePlayerStatisticsResult obj)
    {
        print("New stats saved");
       
    }

    private void OnPlayFabError(PlayFabError obj)
    {
        print("Something went wrong in the stats script");
    }
}
