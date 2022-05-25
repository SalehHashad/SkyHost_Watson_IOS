using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class TestManager : MonoBehaviour
{
    public PlayFabLoginScript Login;
    public GameObject[] Levels;
    public GameObject ResetScreen,End;
    public string Test1Q1;
    public string Test1Q2;
    public string Test1Q3;
    public string Test1Q4;
    public string Test1Q5;
    public string Test1Q6;
    public string Test1Q7;
    public string Test1Q8;
    public string Test1Q9;
    public string Test1Q10;
    public string Test1Q11;
    public string Test1Q12;
    public string Test1Q13;
    public string Test1Q14;
    public string Test1Q15;
    public string Test1Q16;
    public string Test1Q17;
    public string Test1Q18;
    public string Test1Q19;
    public string Test1Q20;
    public GameObject thisPanel;
    public int TestResult = 0;
    public string FirstTest;
    public GameObject TestDone;



    int currentLevel;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Test1Done"))
            {
            TestDone.SetActive(true);
            }
        thisPanel = this.gameObject;
        //GetUserData("2E837");
    }
    public void wrongAnswer()
    {
        if (currentLevel + 1 != Levels.Length)
        {
            if (currentLevel + 1 == 1)
            {
                Test1Q1 = "false";
            }
            if (currentLevel + 1 == 2)
            {
                Test1Q2 = "false";
            }
            if (currentLevel + 1 == 3)
            {
                Test1Q3 = "false";
            }
            if (currentLevel + 1 == 4)
            {
                Test1Q4 = "false";
            }
            if (currentLevel + 1 == 5)
            {
                Test1Q5 = "false";
            }
            if (currentLevel + 1 == 6)
            {
                Test1Q6 = "false";
            }
            if (currentLevel + 1 == 7)
            {
                Test1Q7 = "false";
            }
            if (currentLevel + 1 == 8)
            {
                Test1Q8 = "false";
            }
            if (currentLevel + 1 == 9)
            {
                Test1Q9 = "false";
            }
            if (currentLevel + 1 == 10)
            {
                Test1Q10 = "false";
            }
            if (currentLevel + 1 == 11)
            {
                Test1Q11 = "false";
            }
            if (currentLevel + 1 == 12)
            {
                Test1Q12 = "false";
            }
            if (currentLevel + 1 == 13)
            {
                Test1Q13 = "fasle";
            }
            if (currentLevel + 1 == 14)
            {
                Test1Q14 = "false";
            }
            if (currentLevel + 1 == 15)
            {
                Test1Q15 = "false";
            }
            if (currentLevel + 1 == 16)
            {
                Test1Q16 = "fasle";
            }
            if (currentLevel + 1 == 17)
            {
                Test1Q17 = "false";
            }
            if (currentLevel + 1 == 18)
            {
                Test1Q18 = "false";
            }
            if (currentLevel + 1 == 19)
            {
                Test1Q19 = "false";
            }
            if (currentLevel + 1 == 20)
            {
                Test1Q20 = "false";
            }
            Levels[currentLevel].SetActive(false);

            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else
        {
            SetUserData();
            End.SetActive(true);
            PlayerPrefs.SetInt("Test1Done", 1);
            Levels[currentLevel].SetActive(false);
        }
    }

    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


    void SetUserData()
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>() {
            {"TestResult", TestResult+"/20"},
            {"FirstTest", FirstTest}
            
        }
        },
        result => Debug.Log("Successfully updated user data"),
        error => {
            Debug.Log("Got error setting user data Ancestor to Arthur");
            Debug.Log(error.GenerateErrorReport());
        });
    }

    private void Update()
    {
        FirstTest = Test1Q1 + "|" + Test1Q2 + "|" + Test1Q3 + "|" + Test1Q4 + "|" + Test1Q5 + "|" + Test1Q6 + "|" + Test1Q7 + "|" + Test1Q8 + "|" + Test1Q9 + "|" + Test1Q10 + "|" + Test1Q11 + "|" + Test1Q12 + "|" + Test1Q13 + "|" + Test1Q14 + "|" + Test1Q15 + "|" + Test1Q16 + "|" + Test1Q17 + "|" + Test1Q18 + "|" + Test1Q19 + "|" + Test1Q20;

    }

    void GetUserData(string myPlayFabeId)
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myPlayFabeId,
            Keys = null
        }, result => {
            Debug.Log("Got user data:");
            if (result.Data == null || !result.Data.ContainsKey("TestResult")) thisPanel.SetActive(false);
            else Debug.Log("Q1: " + result.Data["TestResult"].Value);
        }, (error) => {
            Debug.Log("Got error retrieving user data:");
            Debug.Log(error.GenerateErrorReport());
        });
    }

    
    public void correctAnswer()
    {
        if(currentLevel + 1 != Levels.Length)
        {
            if(currentLevel + 1 == 1)
            {
                Test1Q1 = "true";
            }
            if (currentLevel + 1 == 2)
            {
                Test1Q2 = "true";
            }
            if (currentLevel + 1 == 3)
            {
                Test1Q3 = "true";
            }
            if (currentLevel + 1 == 4)
            {
                Test1Q4 = "true";
            }
            if (currentLevel + 1 == 5)
            {
                Test1Q5 = "true";
            }
            if (currentLevel + 1 == 6)
            {
                Test1Q6 = "true";
            }
            if (currentLevel + 1 == 7)
            {
                Test1Q7 = "true";
            }
            if (currentLevel + 1 == 8)
            {
                Test1Q8 = "true";
            }
            if (currentLevel + 1 == 9)
            {
                Test1Q9 = "true";
            }
            if (currentLevel + 1 == 10)
            {
                Test1Q10 = "true";
            }
            if (currentLevel + 1 == 11)
            {
                Test1Q11 = "true";
            }
            if (currentLevel + 1 == 12)
            {
                Test1Q12 = "true";
            }
            if (currentLevel + 1 == 13)
            {
                Test1Q13 = "true";
            }
            if (currentLevel + 1 == 14)
            {
                Test1Q14 = "true";
            }
            if (currentLevel + 1 == 15)
            {
                Test1Q15 = "true";
            }
            if (currentLevel + 1 == 16)
            {
                Test1Q16 = "true";
            }
            if (currentLevel + 1 == 17)
            {
                Test1Q17 = "true";
            }
            if (currentLevel + 1 == 18)
            {
                Test1Q18 = "true";
            }
            if (currentLevel + 1 == 19)
            {
                Test1Q19 = "true";
            }
            if (currentLevel + 1 == 20)
            {
                Test1Q20 = "true";
            }
            Levels[currentLevel].SetActive(false);

            currentLevel++;
            TestResult++;
            Levels[currentLevel].SetActive(true);
        }
        else
        {
            SetUserData();
            End.SetActive(true);
            PlayerPrefs.SetInt("Test1Done", 1);
            Levels[currentLevel].SetActive(false);
        }
    }




}
