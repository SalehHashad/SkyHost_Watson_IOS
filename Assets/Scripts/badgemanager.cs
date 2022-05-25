using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badgemanager : MonoBehaviour
{
    public GameObject[] Badges;
    public int questionnbr;
    public int badgenbr;

    // Start is called before the first frame update
    void Start()
    {
        questionnbr = PlayerPrefs.GetInt("QuestionIndex", 0);
        badgenbr = questionnbr;
        if (badgenbr == 0)
        {

        }
        if (badgenbr > 0)
        {
            for (int i = 0; i < badgenbr; i++)
            {
                Badges[i].SetActive(true);
            }
        }
        //if (badgenbr == 1)
        //{
        //    for (int i = 0; i < 1; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 2)
        //{
        //    for (int i = 0; i < 2; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 3)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 4)
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 5)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 6)
        //{
        //    for (int i = 0; i < 6; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 7)
        //{
        //    for (int i = 0; i < 7; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 8)
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 9)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 10)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 11)
        //{
        //    for (int i = 0; i < 11; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 12)
        //{
        //    for (int i = 0; i < 12; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 13)
        //{
        //    for (int i = 0; i < 13; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 14)
        //{
        //    for (int i = 0; i < 14; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 15)
        //{
        //    for (int i = 0; i < 15; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 16)
        //{
        //    for (int i = 0; i < 16; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 17)
        //{
        //    for (int i = 0; i < 17; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 18)
        //{
        //    for (int i = 0; i < 18; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 19)
        //{
        //    for (int i = 0; i < 19; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 20)
        //{
        //    for (int i = 0; i < 20; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 21)
        //{
        //    for (int i = 0; i < 21; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 8)
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 9)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 10)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 11)
        //{
        //    for (int i = 0; i < 11; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 12)
        //{
        //    for (int i = 0; i < 12; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 13)
        //{
        //    for (int i = 0; i < 13; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}
        //if (badgenbr == 14)
        //{
        //    for (int i = 0; i < 14; i++)
        //    {
        //        Badges[i].SetActive(true);
        //    }
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
