using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class TestManager1 : MonoBehaviour
{
    public PlayFabLoginScript Login;
    public GameObject[] Levels;
    public GameObject ResetScreen,End;
    public string Test2Q1;
    public string Test2Q2;
    public string Test2Q3;
    public string Test2Q4;
    public string Test2Q5;
    public string Test2Q6;
    public string Test2Q7;
    public string Test2Q8;
    public string Test2Q9;
    public string Test2Q10;
    public string Test2Q11;
    public string Test2Q12;
    public string Test2Q13;
    public string Test2Q14;
    public string Test2Q15;
    public string Test2Q16;
    public string Test2Q17;
    public string Test2Q18;
    public string Test2Q19;
    public string Test2Q20;
    public GameObject thisPanel;
    public int TestResult = 0;
    public string FirstTest;
    public GameObject TestDone;



    int currentLevel;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Test2Done"))
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
                Test2Q1 = "false";
            }
            if (currentLevel + 1 == 2)
            {
                Test2Q2 = "false";
            }
            if (currentLevel + 1 == 3)
            {
                Test2Q3 = "false";
            }
            if (currentLevel + 1 == 4)
            {
                Test2Q4 = "false";
            }
            if (currentLevel + 1 == 5)
            {
                Test2Q5 = "false";
            }
            if (currentLevel + 1 == 6)
            {
                Test2Q6 = "false";
            }
            if (currentLevel + 1 == 7)
            {
                Test2Q7 = "false";
            }
            if (currentLevel + 1 == 8)
            {
                Test2Q8 = "false";
            }
            if (currentLevel + 1 == 9)
            {
                Test2Q9 = "false";
            }
            if (currentLevel + 1 == 10)
            {
                Test2Q10 = "false";
            }
            if (currentLevel + 1 == 11)
            {
                Test2Q11 = "false";
            }
            if (currentLevel + 1 == 12)
            {
                Test2Q12 = "false";
            }
            if (currentLevel + 1 == 13)
            {
                Test2Q13 = "fasle";
            }
            if (currentLevel + 1 == 14)
            {
                Test2Q14 = "false";
            }
            if (currentLevel + 1 == 15)
            {
                Test2Q15 = "false";
            }
            if (currentLevel + 1 == 16)
            {
                Test2Q16 = "fasle";
            }
            if (currentLevel + 1 == 17)
            {
                Test2Q17 = "false";
            }
            if (currentLevel + 1 == 18)
            {
                Test2Q18 = "false";
            }
            if (currentLevel + 1 == 19)
            {
                Test2Q19 = "false";
            }
            if (currentLevel + 1 == 20)
            {
                Test2Q20 = "false";
            }
            Levels[currentLevel].SetActive(false);

            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else
        {
            SetUserData();
            End.SetActive(true);
            PlayerPrefs.SetInt("Test2Done", 1);
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
        FirstTest = Test2Q1 + "|" + Test2Q2 + "|" + Test2Q3 + "|" + Test2Q4 + "|" + Test2Q5 + "|" + Test2Q6 + "|" + Test2Q7 + "|" + Test2Q8 + "|" + Test2Q9 + "|" + Test2Q10 + "|" + Test2Q11 + "|" + Test2Q12 + "|" + Test2Q13 + "|" + Test2Q14 + "|" + Test2Q15 + "|" + Test2Q16 + "|" + Test2Q17 + "|" + Test2Q18 + "|" + Test2Q19 + "|" + Test2Q20;
        
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
                Test2Q1 = "true";
            }
            if (currentLevel + 1 == 2)
            {
                Test2Q2 = "true";
            }
            if (currentLevel + 1 == 3)
            {
                Test2Q3 = "true";
            }
            if (currentLevel + 1 == 4)
            {
                Test2Q4 = "true";
            }
            if (currentLevel + 1 == 5)
            {
                Test2Q5 = "true";
            }
            if (currentLevel + 1 == 6)
            {
                Test2Q6 = "true";
            }
            if (currentLevel + 1 == 7)
            {
                Test2Q7 = "true";
            }
            if (currentLevel + 1 == 8)
            {
                Test2Q8 = "true";
            }
            if (currentLevel + 1 == 9)
            {
                Test2Q9 = "true";
            }
            if (currentLevel + 1 == 10)
            {
                Test2Q10 = "true";
            }
            if (currentLevel + 1 == 11)
            {
                Test2Q11 = "true";
            }
            if (currentLevel + 1 == 12)
            {
                Test2Q12 = "true";
            }
            if (currentLevel + 1 == 13)
            {
                Test2Q13 = "true";
            }
            if (currentLevel + 1 == 14)
            {
                Test2Q14 = "true";
            }
            if (currentLevel + 1 == 15)
            {
                Test2Q15 = "true";
            }
            if (currentLevel + 1 == 16)
            {
                Test2Q16 = "true";
            }
            if (currentLevel + 1 == 17)
            {
                Test2Q17 = "true";
            }
            if (currentLevel + 1 == 18)
            {
                Test2Q18 = "true";
            }
            if (currentLevel + 1 == 19)
            {
                Test2Q19 = "true";
            }
            if (currentLevel + 1 == 20)
            {
                Test2Q20 = "true";
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
            PlayerPrefs.SetInt("Test2Done", 1);
            Levels[currentLevel].SetActive(false);
        }
    }

    


}
