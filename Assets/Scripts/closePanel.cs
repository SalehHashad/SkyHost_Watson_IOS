using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closePanel : MonoBehaviour
{
    public GameObject thispanel;
    // Start is called before the first frame update
    void OnEnable()
    {
        thispanel = this.gameObject;
    }

    public void hidethispanel()
    {
        thispanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
