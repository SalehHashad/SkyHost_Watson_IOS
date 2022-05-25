using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResp : MonoBehaviour
{
    public int Number;
    public int PanelNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Question")) 
        {
            PanelNumber = collision.gameObject.GetComponent<QuestionsCol>().Number;
            if (PanelNumber == Number)
            {
                Debug.Log("good" + Number);
            }
            else
            {
                Debug.Log("false");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
