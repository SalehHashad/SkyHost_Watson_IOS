using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBtn : MonoBehaviour
{
    public GameObject PopUpImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void closepop()
    {
        PopUpImage.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
