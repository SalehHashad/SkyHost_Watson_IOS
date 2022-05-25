using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tets : MonoBehaviour
{
    public int nbr = 3;
    public int q = 3;
    // Start is called before the first frame update
    void Start()
    {

        int xnbr = q / nbr;
        Debug.Log(xnbr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
