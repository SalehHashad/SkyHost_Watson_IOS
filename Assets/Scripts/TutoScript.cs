using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoScript : MonoBehaviour
{
    public GameObject[] Tuto;
    public int indx =0;
    public GameObject TutoPanel;
    public GameObject SideMenuPanel;
   
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        indx = 0;
        TutoPanel = this.gameObject;
        if (PlayerPrefs.GetInt("tuto")==1)
        {
            SideMenuPanel.SetActive(false);
            TutoPanel.SetActive(false);
        }
        
        LoopTuto();
    }

    public void LoopTuto()
    {
        //foreach (GameObject TutoP in Tuto)
        //{
        //    TutoP[i].SetActive(true);
        //}
        for (int i = 0; i < Tuto.Length; i++)
        {
            Tuto[i].SetActive(false);
            if (i == indx) 
            {
            
            Tuto[indx].SetActive(true);
            }
            //else
            //{
            //    Tuto[indx].SetActive(false);
            //}
            
            
            
        }
        if (indx == Tuto.Length)
        {
            Invoke("hidepanel", 1);
            
            
        }
        Invoke("LoopTuto", 2);
        indx++;
    }
    void hidepanel()
    {
        PlayerPrefs.SetInt("tuto", 1);
        SideMenuPanel.SetActive(false);
        TutoPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
