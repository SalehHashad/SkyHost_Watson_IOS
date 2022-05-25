using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChecker : MonoBehaviour
{
    //public CheckResp _checkResp;
    // Start is called before the first frame update
    public string ObjectId = "object1";
    public int PanelNumber;
    public GameObject QuestionAns;
    public GameObject ActivePanel;
    public QuestionManager questionManager;
    
    

    private void Awake()
    {

        //_checkResp = _checkResp.GetComponent<CheckResp>();
        //_checkResp.enabled = false;
    }
    void Start()
    {
        
    }

    public void ActiveCheck()
    {
        ActivePanel = questionManager.ActiveQpanel;
        int QuestionPanelNumber =PlayerPrefs.GetInt("QuestionIndex", 0)+1;
        string Object1Panel = DragDropManager.GetObjectPanel(ObjectId);
        Debug.Log(Object1Panel);
        string panelid = Object1Panel;
        PanelNumber  = Convert.ToInt32(panelid);
        int NumberId = Convert.ToInt32(ObjectId);
        if (NumberId == PanelNumber)
        {
            if(NumberId == 1)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q01 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q1pose = transform.position;
            }

            if (NumberId == 2)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q02 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q2pose = transform.position;
            }
            if (NumberId == 3)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q03 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q3pose = transform.position;
            }
            if (NumberId == 4)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q04 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q4pose = transform.position;
            }
            if (NumberId == 5)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q05 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q5pose = transform.position;
            }
            if (NumberId == 6)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q06 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q6pose = transform.position;
            }
            if (NumberId == 7)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q07 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q7pose = transform.position;
            }
            if (NumberId == 8)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q08 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q8pose = transform.position;
            }
            if (NumberId == 9)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q09 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q9pose = transform.position;
            }
            if (NumberId == 10)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q010 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q10pose = transform.position;
            }
            if (NumberId == 11)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q011 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q11pose = transform.position;
            }
            if (NumberId == 12)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q012 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q12pose = transform.position;
            }
            if (NumberId == 13)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q013 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q13pose = transform.position;
            }
            if (NumberId == 14)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q014 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q14pose = transform.position;
            }
            if (NumberId == 15)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q015 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q15pose = transform.position;
            }
            if (NumberId == 16)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q016 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q16pose = transform.position;
            }
            if (NumberId == 17)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q017 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q17pose = transform.position;
            }
            if (NumberId == 18)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q018 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q18pose = transform.position;
            }
            if (NumberId == 19)
            {
                ActivePanel.GetComponent<DataPanelQ>().Q019 = 1;
                ActivePanel.GetComponent<DataPanelQ>().Q19pose = transform.position;
            }
            
            //"Q0"+ NumberId; 
            
            string Questionanswerinpanel = "Q"+QuestionPanelNumber.ToString() + "-" + NumberId.ToString();
            Debug.Log(Questionanswerinpanel);
            PlayerPrefs.SetInt(Questionanswerinpanel, 1);

            Debug.Log("good" + NumberId);
        }
        else
        {
            if (NumberId!= PanelNumber)
            {
                if (NumberId == 1)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q01 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q1pose = GetComponent<INITIALPOSS>().InitialPosition;
                }

                if (NumberId == 2)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q02 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q2pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 3)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q03 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q3pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 4)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q04 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q4pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 5)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q05 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q5pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 6)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q06 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q6pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 7)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q07 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q7pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 8)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q08 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q8pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 9)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q09 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q9pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 10)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q010 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q10pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 11)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q011 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q11pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 12)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q012 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q12pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 13)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q013 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q13pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 14)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q014 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q14pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 15)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q015 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q15pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 16)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q016 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q16pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 17)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q017 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q17pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 18)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q018 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q18pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
                if (NumberId == 19)
                {
                    ActivePanel.GetComponent<DataPanelQ>().Q019 = 0;
                    ActivePanel.GetComponent<DataPanelQ>().Q19pose = GetComponent<INITIALPOSS>().InitialPosition;
                }
            }

            string Questionanswerinpanel = "Q" + QuestionPanelNumber.ToString() + "-" + NumberId.ToString();
            Debug.Log(Questionanswerinpanel);
            PlayerPrefs.SetInt(Questionanswerinpanel, 0);
            Debug.Log("false" + NumberId);

        }
    }
    // Update is called once per frame
    void Update()
    {
        ActivePanel = questionManager.ActiveQpanel;
    }
}
