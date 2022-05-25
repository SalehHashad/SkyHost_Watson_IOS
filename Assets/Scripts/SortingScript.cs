using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SortingScript : MonoBehaviour
{
    public TextMeshProUGUI text;

    [SerializeField]
    DataFromServer dataFromServer = new DataFromServer();

    public string str;

    void Start()
    {
        string[] arr = str.Split('"');
        print(arr[1]);
        //foreach (Questions questions in dataFromServer.data)
        //{
        //    print(questions.Question);
        //}
    }

    public void FindStringMatch()
    {
        SplitString(text.text);
    }

    void SplitString(string str)
    {
       string[] word= str.Split(' ');
        foreach(string splitWord in word)
        {
            //print(splitWord);
            FindInString(splitWord);
        }
    }

    void FindInString(string str)
    {
        foreach (Questions questions in dataFromServer.data)
        {
            if (questions.Question.Contains(str))
            {
                print(questions.Question);
            }
        }
    }

}

[System.Serializable]
public class DataFromServer
{
    public List<Questions> data;
}

[System.Serializable]
public class Questions
{
    public int ID;
    public string Question;
    public string Answer;
}

