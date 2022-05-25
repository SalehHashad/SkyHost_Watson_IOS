using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoonect : MonoBehaviour
{
    public PlayFabLoginScript Login;
    // Start is called before the first frame update
    void Start()
    {
       // Login = GetComponent<PlayFabLoginScript>();
        InvokeRepeating("ReConnect", 15, 600);
    }

    public void ReConnect()
    {
        Login.Login();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
