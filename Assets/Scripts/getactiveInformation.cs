using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class getactiveInformation : MonoBehaviour
{
    public GameObject AudioBotbtn;
    public GameObject TextBotbtn;
    public int Active=0;
    // Start is called before the first frame update

    private void Awake()
    {
        //PlayerPrefs.SetInt("ActiveAcount",1);
        Active = PlayerPrefs.GetInt("ActiveAcount");
        if (Active == 1)
        {
            AudioBotbtn.SetActive(true);
            TextBotbtn.SetActive(false);
        }
        if (Active == 2)
        {
            AudioBotbtn.SetActive(false);
            TextBotbtn.SetActive(true);
        }
        if (Active == 3)
        {
            AudioBotbtn.SetActive(true);
            TextBotbtn.SetActive(true);
        }
    }
    void Start()
    {
        //AudioBotbtn.SetActive(false);
        //AudioBotbtn.SetActive(false);
        //if (Active == 1)
        //{
        //    AudioBotbtn.SetActive(true);
        //    AudioBotbtn.SetActive(false);
        //}
        //if (Active == 2)
        //{
        //    AudioBotbtn.SetActive(false);
        //    AudioBotbtn.SetActive(true);
        //}
        //if (Active == 3)
        //{
        //    AudioBotbtn.SetActive(true);
        //    AudioBotbtn.SetActive(true);
        //}
        //Debug.Log(PlayerPrefs.GetInt("ActiveAcount"));
    }

    public void Loadgamescen()
    {
        SceneManager.LoadScene("Gamification");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
