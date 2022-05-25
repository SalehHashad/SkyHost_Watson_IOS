using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPreviousAnswer : MonoBehaviour
{
    public GameObject PreviousAnswer;
    // Start is called before the first frame update
    void Start()
    {
        PreviousAnswer.SetActive(false);
    }

    public void ShowPreviousAns()
    {
        PreviousAnswer.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
