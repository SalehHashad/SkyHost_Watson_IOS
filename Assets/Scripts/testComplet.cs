using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testComplet : MonoBehaviour
{
    public GameObject Test2;
    // Start is called before the first frame update
    private void Awake()
    {
        Test2.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Test2Done") == 1)
        {
            Test2.SetActive(true);
        }
    }
}
