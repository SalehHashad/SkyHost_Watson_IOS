using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarterGames.Assets.SaveManager;



namespace CarterGames.Assets.SaveManager.Example
{
    public class questionAnswerss : MonoBehaviour
{
    public SaveData _data;
    // Start is called before the first frame update
    public int QuestionPanelNumber;
    public int question1 = 0;
    public Vector3 question1Int;
    public Vector3 question1last;
    public int question2 = 0;
    public Vector3 question2Int;
    public Vector3 question2last;
    public int question3 = 0;
    public Vector3 question3Int;
    public Vector3 question3last;
    public int question4 = 0;
    public Vector3 question4Int;
    public Vector3 question4last;
    public int question5 = 0;
    public Vector3 question5Int;
    public Vector3 question5last;
    public int question6 = 0;
    public Vector3 question6Int;
    public Vector3 question6last;
    public int question7 = 0;
    public Vector3 question7Int;
    public Vector3 question7last;
    public int question8 = 0;
    public Vector3 question8Int;
    public Vector3 question8last;
    public int question9 = 0;
    public Vector3 question9Int;
    public Vector3 question9last;
    public int question10 = 0;
    public Vector3 question10Int;
    public Vector3 question10last;

    public GameObject Number1;
    public GameObject Number2;
    public GameObject Number3;
    public GameObject Number4;
    public GameObject Number5;
    public GameObject Number6;
    public GameObject Number7;
    public GameObject Number8;
    public GameObject Number9;
    public GameObject Number10;

    public int TotalForThisAnswer;
    public GameObject ActivePanel;
    public int NumberofPic;
    public float purcentageof;

    
    //[System.Serializable]
    //public class QuestionData
    //{

    //    public string Panelname;
    //    public int QuestionPanelNumber;
    //    public int question1 = 0;
    //    public Vector3 question1Int;
    //    public Vector3 question1last;
    //    public int question2 = 0;
    //    public Vector3 question2Int;
    //    public Vector3 question2last;
    //    public int question3 = 0;
    //    public Vector3 question3Int;
    //    public Vector3 question3last;
    //    public int question4 = 0;
    //    public Vector3 question4Int;
    //    public Vector3 question4last;
    //    public int question5 = 0;
    //    public Vector3 question5Int;
    //    public Vector3 question5last;
    //    public int question6 = 0;
    //    public Vector3 question6Int;
    //    public Vector3 question6last;
    //    public int question7 = 0;
    //    public Vector3 question7Int;
    //    public Vector3 question7last;
    //    public int question8 = 0;
    //    public Vector3 question8Int;
    //    public Vector3 question8last;
    //    public int question9 = 0;
    //    public Vector3 question9Int;
    //    public Vector3 question9last;
    //    public int question10 = 0;
    //    public Vector3 question10Int;
    //    public Vector3 question10last;

    //}


    void Start()
    {
        //question1Int=Number1.transform.position;
        //question2Int=Number2.transform.position;
        //question3Int=Number3.transform.position;
        //question4Int=Number4.transform.position;
        //question5Int=Number5.transform.position;
        //question6Int=Number6.transform.position;
        //question7Int=Number7.transform.position;
        //question8Int=Number8.transform.position;
        //question9Int=Number9.transform.position;
        //question10Int=Number10.transform.position;

    }

    public void ResetCounting()
    {
        //Number1.transform.position = question1Int;
        //Number2.transform.position = question2Int;
        //Number3.transform.position = question3Int;
        //Number4.transform.position = question4Int;
        //Number5.transform.position = question5Int;
        //Number6.transform.position = question6Int;
        //Number7.transform.position = question7Int;
        //Number8.transform.position = question8Int;
        //Number9.transform.position = question9Int;
        //Number10.transform.position = question10Int;
    }

    public void getdatapanel()
    {
        TotalForThisAnswer = question1 + question2 + question3 + question4 + question5 + question6 + question7 + question8 + question9 + question10;
        NumberofPic = ActivePanel.transform.childCount;
        purcentageof = (((float)NumberofPic - (float)TotalForThisAnswer) * 100.0f) / (float)NumberofPic;
       
    }

        public void SaveGame()
        {
            _data = new SaveData();
            _data.Q101 = 1;
            _data.Q102 = 5;


            SaveManager.SaveGame(_data);
            SaveData loadData = SaveManager.LoadGame();
            Debug.Log(loadData.Q101 + " " + loadData.Q102);
        }

        // Update is called once per frame
        void Update()
    {
        
    }
}
}
