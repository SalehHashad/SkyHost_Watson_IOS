using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;

public class getbtnfromchildren : MonoBehaviour
{
    public Mark[] Btns;
    public string Name1;
    public string Score1;
    public string Name2;
    public string Score2;
    public string Name3;
    public string Score3;
    public GameObject Child1;
    public GameObject Child2;
    public GameObject Child3;
    public RTLTextMeshPro Child1Name;
    public RTLTextMeshPro Child2Name;
    public RTLTextMeshPro Child3Name;
    public RTLTextMeshPro Child1score;
    public RTLTextMeshPro Child2score;
    public RTLTextMeshPro Child3score;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("getchild", 1f);
    }
    private void OnEnable()
    {
        
    }

    public void getchild()
    {
        if (transform.GetChild(0).gameObject != null) { 
            Child1 = transform.GetChild(0).gameObject;
            Name1 = Child1.GetComponent<ScoreRecord>().namee;
            Child1Name.text = Name1;
            Score1 = Child1.GetComponent<ScoreRecord>().scoree;
            Child1score.text = Score1;
        }
        if (transform.GetChild(1).gameObject != null)
        {
            Child2 = transform.GetChild(1).gameObject;
            Name2 = Child2.GetComponent<ScoreRecord>().namee;
            Child2Name.text = Name2;
            Score2 = Child2.GetComponent<ScoreRecord>().scoree;
            Child2score.text = Score2;
        }
        if (transform.GetChild(2).gameObject != null)
        {
            Child3 = transform.GetChild(2).gameObject;
            Name3 = Child3.GetComponent<ScoreRecord>().namee;
            Child3Name.text = Name3;
            Child3score.text = Child3.GetComponent<ScoreRecord>().scoree;
            Child3score.text = Score3;


        }
    }

    public void destroychild()
    {
        Btns = GetComponentsInChildren<Mark>();
        foreach (Mark btn in Btns)
            btn.gameObject.SetActive(false);
    }
    
}
