using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchZoom : MonoBehaviour
{

    float distance;
    public float maxScale = 10f;
    public float minScale = .01f;

    public int smoothValue = 200;


    void Update()
    {

        if (Input.touchCount == 2)
        {

            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);
            Vector3 currentDist = touch0.position - touch1.position;
            Vector3 prevDist = (touch0.position - touch0.deltaPosition) - (touch1.position - touch1.deltaPosition);

            //The magnitude of two vectors is to be calculated which gives a very large value. Dividing by an integer triggers the smoothness of the changing value of the delta.

            float delta = (currentDist.magnitude - prevDist.magnitude) / smoothValue;
            distance += delta;

            if (distance < minScale)
            {
                distance = minScale;
            }
            if (distance > maxScale)
            {
                distance = maxScale;
            }
            gameObject.transform.localScale = new Vector3(distance, distance, distance);
        }


    }
}
