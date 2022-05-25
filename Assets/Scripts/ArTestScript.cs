using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArTestScript : MonoBehaviour
{
    public Camera arCam;
    public ARRaycastManager rRaycastManager;
    public GameObject objectToSpawned;
    public GameObject spawnedObject;
    public ARPlaneManager aRSession;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    bool btnClicked;
    bool tryGetTouchPosition(out Vector2 touchPos)
    {
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            return true;
        }
        touchPos = default;
        return false;
    }


    void Update()
    {
        if (!btnClicked)
        {
            return;
        }
        if (spawnedObject == null)
        {
            Ray ray = arCam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            if (rRaycastManager.Raycast(ray, _hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPos = _hits[0].pose;

                spawnedObject = Instantiate(objectToSpawned, hitPos.position, hitPos.rotation);
                //spawnedObject.transform.rotation= Quaternion. (0,180+ arCam.transform.rotation, 0);
                btnClicked = false;
                aRSession.enabled = false;

                gameObject.SetActive(false);
            }
        }
        
    }

    public void OnBtnClicked()
    {
        btnClicked = true;
    }
}
