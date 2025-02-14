using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSplit : MonoBehaviour
{
    private Camera cam;
    private Camera leftEyeCam, rightEyeCam;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Create left and right eye cameras
        CreateEyeCameras();
    }

    void CreateEyeCameras()
    {
        

    }
}
