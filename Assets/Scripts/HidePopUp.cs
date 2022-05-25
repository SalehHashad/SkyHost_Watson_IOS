using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePopUp : MonoBehaviour
{
    public GameObject PopUp;
    // Start is called before the first frame update
    void Start()
    {
        PopUp = this.gameObject;
        Invoke("hidethis", 0.05f);
    }

    public void hidethis()
    {
        PopUp.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
