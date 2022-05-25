using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerdQuestion : MonoBehaviour
{
    public GameObject Thispanel;
    public GameObject[] QuesionsP;
    public Texture[] Headers;
    public RawImage HeaderRaw;
    public GameObject headerpanel;
    public GameObject[] AllQpanel;
    public GameObject ActiveQpanel;
    public int IndexQ=0;
    public int IndexR;
    public Button Previous;
    public Button Next;
    // Start is called before the first frame update
    void Start()
    {
        Thispanel = this.gameObject;
        HeaderRaw = headerpanel.GetComponent<RawImage>();
        HeaderRaw.texture = Headers[IndexQ];
        IndexR = IndexR = PlayerPrefs.GetInt("ResponseIndex", 0);
        for (int i = 0; i < QuesionsP.Length; i++)
        {
            if (QuesionsP[i] == QuesionsP[IndexQ])
            {
                //QuesionsP[i].transform.position = InitialPosP;

                QuesionsP[i].SetActive(true);
            }
            else
            {
                QuesionsP[i].SetActive(false);
            }
        }
        ActiveQpanel = AllQpanel[IndexQ];

    }

    public void NextPanel()
    {
        IndexQ++;
    }
    public void PrevisouPanel()
    {
        IndexQ--;
    }
    void ShowRightPAnel()
    {
        //IndexQ = PlayerPrefs.GetInt("QuestionIndex", 0);
        //Fetch the RawImage component from the GameObject
        HeaderRaw = headerpanel.GetComponent<RawImage>();
        //Change the Texture to be the one 
        HeaderRaw.texture = Headers[IndexQ];
        for (int i = 0; i < QuesionsP.Length; i++)
        {
            if (QuesionsP[i] == QuesionsP[IndexQ])
            {
                // QuesionsP[i].transform.position = InitialPosP;

                QuesionsP[i].SetActive(true);
            }
            else
            {
                //QuesionsP[i].transform.position = new Vector3(3000f, transform.position.y, transform.position.z);
                QuesionsP[i].SetActive(false);
            }
        }
        ActiveQpanel = AllQpanel[IndexQ];
    }
    // Update is called once per frame
    void Update()
    {
        if (IndexQ == 0)
        {
            Previous.interactable = false;
        }
        if (IndexQ > 0)
        {
            Previous.interactable = true;
        }
        if(IndexQ >= IndexR)
        {
            Next.interactable = false;
        }
        if (IndexQ < IndexR)
        {
            Next.interactable = true;
        }
        ShowRightPAnel();
    }
    public void HidePanel()
    {
        Thispanel.SetActive(false);
    }
}
