using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaffleorder : MonoBehaviour
{
   
    public int QuesNumber;
    // Start is called before the first frame update
    private void Awake()
    {
        foreach (Transform child in transform)
            //print(child.gameObject.name);
            child.SetSiblingIndex(Random.Range(1,5));


        foreach (Transform child in transform)
            if (child.name.Contains("x"))
                child.SetSiblingIndex((transform.childCount / 2) );

    }

    private void OnEnable()
    {
        PlayerPrefs.SetInt("QpanelNbr", QuesNumber);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
