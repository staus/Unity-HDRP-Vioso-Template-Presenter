using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour
{
    GameObject projectorsCameras;
    Vector3 tempRotation;
    Vector3 projectorsCamerasDefaultPosition = new Vector3(3.5f, 1.8f, 4f);
    void Awake() {
        projectorsCameras = GameObject.Find("ProjectorsCameras");
    }
    void Start()
    {
        
    }
    void OnEnable() {
        tempRotation = transform.eulerAngles;
        tempRotation.y += 180;
        projectorsCameras.transform.eulerAngles = tempRotation;
        projectorsCameras.transform.position = transform.position;
    }
    void OnDisable() {
        projectorsCameras.transform.eulerAngles = new Vector3(0,180,0);
        projectorsCameras.transform.localPosition = projectorsCamerasDefaultPosition;
    }

    void Update()
    {
        tempRotation = transform.eulerAngles;
        tempRotation.y += 180;
        projectorsCameras.transform.eulerAngles = tempRotation;
        projectorsCameras.transform.position = transform.position;
        //projectorsCameras.transform.rotation = transform.rotation;
    }
}
