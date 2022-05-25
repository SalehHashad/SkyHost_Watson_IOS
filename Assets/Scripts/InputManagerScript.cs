using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InputManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToInstatiate;
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;
    [SerializeField] public ARPlaneManager arPlaneManager;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private GameObject spawnedObject;
    bool btnClicked, stopAwait;

    public async Task PlaceARBot()
    {
        if (!btnClicked)
        {
            btnClicked = true;
            await WaitForTask();
        }
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
            if (_raycastManager.Raycast(ray, _hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPos = _hits[0].pose;

                spawnedObject = Instantiate(objectToInstatiate, hitPos.position, Quaternion.identity);
               // spawnedObject.transform.rotation = Quaternion.Euler(0,180+ arCam.transform.rotation.eulerAngles.y, 0);
               // print(spawnedObject.transform.rotation);
               // ChangeRot(spawnedObject);
                //spawnedObject.transform.rotation= Quaternion. (0,180+ arCam.transform.rotation, 0);
                btnClicked = false;

                foreach(var plane in arPlaneManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }

                arPlaneManager.enabled = false;

                gameObject.SetActive(false);
                stopAwait = true;
            }
        }

    }

    void ChangeRot(GameObject obj)
    {

        obj.transform.rotation = Quaternion.Euler(0, 180, 0);
        print(obj.transform.rotation);

    }


    async Task WaitForTask()
    {
        while (!stopAwait)
        {
            print("Dy");
            await Task.Delay(2000);
            print("Delay");
        }
    }

}
