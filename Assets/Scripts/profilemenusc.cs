using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class profilemenusc : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject TestPanel;
    public GameObject TutoPanel;
    public GameObject LastTest;
    public GameObject sidepanel;

    // Start is called before the first frame update
    private void OnEnable()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
    }
    void Start()
    {
        
    }

    public void ShowPanel2()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        Panel3.SetActive(false);
    }
    public void ShowPanel3()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(true);
    }

    public void HidePanel()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        TutoPanel.SetActive(true);
        Panel3.SetActive(false);
        if(PlayerPrefs.GetInt("tuto",0)== 0)
        {
            sidepanel.SetActive(true);
            TutoPanel.SetActive(true);
            
        }
        if (PlayerPrefs.GetInt("tuto", 0) == 1)
        {
            sidepanel.SetActive(false);
            TutoPanel.SetActive(false);

        }
        if (PlayerPrefs.GetInt("LastTest", 0) == 0)
        {
            LastTest.SetActive(false);
        }
        if (PlayerPrefs.GetInt("LastTest", 0) == 1)
        {
            LastTest.SetActive(true);
        }
    }

    public void ShowTestPanel()
    {
        TestPanel.SetActive(true);
    }

    public void Gamification()
    {
        SceneManager.LoadScene("Gamification");
    }

    public void AskFateen()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
