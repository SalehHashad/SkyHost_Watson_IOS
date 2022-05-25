using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanels : MonoBehaviour
{
    public GameObject AhdefmarifiaPanel;
    public GameObject AhdefmahariaPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowAhdefmarifya()
    {
        AhdefmarifiaPanel.SetActive(true);
    }
    public void ShowAhdefmaharia()
    {
        AhdefmahariaPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
