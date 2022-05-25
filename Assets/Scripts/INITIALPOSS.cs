using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INITIALPOSS : MonoBehaviour
{
    public Vector3 InitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
