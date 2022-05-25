using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPanelQ : MonoBehaviour
{
    public DragDropManager _dragDrop;
    public int Q01 = 0;
    public int Q02 = 0;
    public int Q03 = 0;
    public int Q04 = 0;
    public int Q05 = 0;
    public int Q06 = 0;
    public int Q07 = 0;
    public int Q08 = 0;
    public int Q09 = 0;
    public int Q010 = 0;
    public int Q011 = 0;
    public int Q012 = 0;
    public int Q013 = 0;
    public int Q014 = 0;
    public int Q015 = 0;
    public int Q016 = 0;
    public int Q017 = 0;
    public int Q018 = 0;
    public int Q019 = 0;
    public Vector3 Q1pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q2pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q3pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q4pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q5pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q6pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q7pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q8pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q9pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q10pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q11pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q12pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q13pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q14pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q15pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q16pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q17pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q18pose = new Vector3(0f, 0f, 0f);
    public Vector3 Q19pose = new Vector3(0f, 0f, 0f);
    public Vector3 nullvector = new Vector3(0f, 0f, 0f);
    public int TrueInswer = 0;
    public int numberofquestion;
    public float purcentageof;
    public GameObject number1;
    public GameObject number2;
    public GameObject number3;
    public GameObject number4;
    public GameObject number5;
    public GameObject number6;
    public GameObject number7;
    public GameObject number8;
    public GameObject number9;
    public GameObject number10;
    public GameObject number11;
    public GameObject number12;
    public GameObject number13;
    public GameObject number14;
    public GameObject number15;
    public GameObject number16;
    public GameObject number17;
    public GameObject number18;
    public GameObject number19;
    

    private void OnEnable()
    {
        GameObject Panel = this.gameObject;
        numberofquestion = Panel.transform.childCount;

        if (numberofquestion == 2)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(false);
            number4.SetActive(false);
            number5.SetActive(false);
            number6.SetActive(false);
            number7.SetActive(false);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 3)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(false);
            number5.SetActive(false);
            number6.SetActive(false);
            number7.SetActive(false);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 4)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(false);
            number6.SetActive(false);
            number7.SetActive(false);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 5)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(false);
            number7.SetActive(false);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 6)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(false);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 7)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 8)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 9)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 10)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 11)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 12)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 13)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 14)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 15)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(true);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 16)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(true);
            number16.SetActive(true);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 17)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(true);
            number16.SetActive(true);
            number17.SetActive(true);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 18)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(true);
            number16.SetActive(true);
            number17.SetActive(true);
            number18.SetActive(true);
            number19.SetActive(false);
        }
        if (numberofquestion == 19)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(true);
            number16.SetActive(true);
            number17.SetActive(true);
            number18.SetActive(true);
            number19.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _dragDrop = GetComponent<DragDropManager>();
        GameObject Panel = this.gameObject;
        numberofquestion= Panel.transform.childCount;
        
    }
    public void PlaceNumber()
    {
        if(Q1pose.x != 0f) { 
        number1.transform.position = Q1pose;
        }
        if (Q2pose.x != 0f)
        {
            number2.transform.position = Q2pose;
         }
        if (Q3pose.x != 0f)
        {
            number3.transform.position = Q3pose;
        }
        if (Q4pose.x != 0f)
        {
            number4.transform.position = Q4pose;
        }
        if(Q5pose.x != 0f) { 
        
        number5.transform.position = Q5pose;
        }
        if (Q6pose.x != 0f)
        {
            number6.transform.position = Q6pose;
        }
        if (Q7pose.x != 0f)
        {
            number7.transform.position = Q7pose;
        }
        if (Q8pose.x != 0f)
        {
            number8.transform.position = Q8pose;
        }
        if (Q9pose.x != 0f)
        {
            number9.transform.position = Q9pose;
        }
        if (Q10pose.x != 0f)
        {
            number10.transform.position = Q10pose;
        }
        if (Q11pose.x != 0f)
        {

            number11.transform.position = Q11pose;
        }
        if (Q12pose.x != 0f)
        {
            number12.transform.position = Q12pose;
        }
        if (Q13pose.x != 0f)
        {
            number13.transform.position = Q13pose;
        }
        if (Q14pose.x != 0f)
        {
            number14.transform.position = Q14pose;
        }
        if (Q15pose.x != 0f)
        {
            number15.transform.position = Q15pose;
        }
        if (Q16pose.x != 0f)
        {
            number16.transform.position = Q16pose;
        }
        if (Q17pose.x != 0f)
        {
            number17.transform.position = Q17pose;
        }
        if (Q18pose.x != 0f)
        {

            number18.transform.position = Q18pose;
        }
        if (Q19pose.x != 0f)
        {
            number19.transform.position = Q19pose;
        }
      
    }
    public void resetnumberdata()
    {
    Q01 = 0;
    Q02 = 0;
    Q03 = 0;
    Q04 = 0;
    Q05 = 0;
    Q06 = 0;
    Q07 = 0;
    Q08 = 0;
    Q09 = 0;
    Q010 = 0;
    Q011 = 0;
    Q012 = 0;
    Q013 = 0;
    Q014 = 0;
    Q015 = 0;
    Q016 = 0;
    Q017 = 0;
    Q018 = 0;
    Q019 = 0;
        Q1pose = nullvector;
        Q2pose = nullvector;
        Q3pose = nullvector;
        Q4pose = nullvector;
        Q5pose = nullvector;
        Q6pose = nullvector;
        Q7pose = nullvector;
        Q8pose = nullvector;
        Q9pose = nullvector;
        Q10pose = nullvector;
        Q11pose = nullvector;
        Q12pose = nullvector;
        Q13pose = nullvector;
        Q14pose = nullvector;
        Q15pose = nullvector;
        Q16pose = nullvector;
        Q17pose = nullvector;
        Q18pose = nullvector;
        Q19pose = nullvector;
        DragDropManager.Reset();
}
    // Update is called once per frame
    void Update()
    {
        _dragDrop = GetComponent<DragDropManager>();
        TrueInswer = Q01 + Q02 + Q03 + Q04 + Q05 + Q06 + Q07+ Q08 + Q09 + Q010 + Q011 + Q012 + Q013 + Q014 + Q015 + Q016 + Q017 + Q018 + Q019;
        purcentageof = 100-(((float)numberofquestion - (float)TrueInswer) * 100.0f) / (float)numberofquestion;
        GameObject Panel = this.gameObject;
        numberofquestion = Panel.transform.childCount;

        if (numberofquestion == 2)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(false);
            number4.SetActive(false);
            number5.SetActive(false);
            number6.SetActive(false);
            number7.SetActive(false);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 3)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(false);
            number5.SetActive(false);
            number6.SetActive(false);
            number7.SetActive(false);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 4)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(false);
            number6.SetActive(false);
            number7.SetActive(false);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 5)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(false);
            number7.SetActive(false);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 6)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(false);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 7)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(false);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 8)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(false);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 9)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(false);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 10)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(false);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 11)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(false);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 12)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(false);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 13)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(false);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 14)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(false);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 15)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(true);
            number16.SetActive(false);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 16)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(true);
            number16.SetActive(true);
            number17.SetActive(false);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 17)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(true);
            number16.SetActive(true);
            number17.SetActive(true);
            number18.SetActive(false);
            number19.SetActive(false);
        }
        if (numberofquestion == 18)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(true);
            number16.SetActive(true);
            number17.SetActive(true);
            number18.SetActive(true);
            number19.SetActive(false);
        }
        if (numberofquestion == 19)
        {
            number1.SetActive(true);
            number2.SetActive(true);
            number3.SetActive(true);
            number4.SetActive(true);
            number5.SetActive(true);
            number6.SetActive(true);
            number7.SetActive(true);
            number8.SetActive(true);
            number9.SetActive(true);
            number10.SetActive(true);
            number11.SetActive(true);
            number12.SetActive(true);
            number13.SetActive(true);
            number14.SetActive(true);
            number15.SetActive(true);
            number16.SetActive(true);
            number17.SetActive(true);
            number18.SetActive(true);
            number19.SetActive(true);
        }
    }
}
