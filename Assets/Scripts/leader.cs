using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leader : MonoBehaviour
{
    public GameObject LeaderBoardPanel;
    public getbtnfromchildren getbtn;
    public GameObject Chld;
    // Start is called before the first frame update
    void Start()
    {
        LeaderBoardPanel = this.gameObject;
    }

    public void hideleaderboard()
    {
        
        getbtn.destroychild();
        LeaderBoardPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
