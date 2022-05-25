using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject LoginPnl;
    public GameObject SignUpPnl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoginPnal()
    {
        SignUpPnl.SetActive(false);
        LoginPnl.SetActive(true);
        
    }
    public void SignUpPnal()
    {
        LoginPnl.SetActive(false);
        SignUpPnl.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
