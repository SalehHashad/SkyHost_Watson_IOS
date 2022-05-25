using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class PlayFabPlayerStats : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
    public void SaveStatsQ(String Qnumber,int value)
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

    private void OnPlayFabError(PlayFabError obj)
    {
        print("Something went wrong in the stats script");
    }

    private void OnSetStatsSuccess(UpdatePlayerStatisticsResult obj)
    {
        print("New stats saved");
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
            print("Statistic: " + stat.StatisticName + " Wert: " + stat.Value);
            PlayerPrefs.SetString("stats", stat.Value.ToString());
        }
    }
}