using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject target;
    private void OnEnable()
    {
        target = GameObject.Find("Traget");
    }

    void Update()
    {
        if (target != null)
        {
            var n = target.transform.position - transform.position;
            n.y = 0;
            transform.rotation = Quaternion.LookRotation(n);
        }
    }
}
