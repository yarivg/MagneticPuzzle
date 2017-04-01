using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraManager : MonoBehaviour
{
    public static InGameCameraType cameraTyp;
    public static List<BaseCamera> allCameras;
    public static float changeCameraTime;

    void Start()
    {
        // Create the ligths for every scene
        allCameras = new List<BaseCamera> { new DayCamera(), new NightCamera() };
    }

    public void changeCamera(int addValue)
    {
        allCameras[(int)cameraTyp].MakeFollow();


        //int CameraTypeCnt = Enum.GetNames(typeof(InGameCameraType)).Length;

        //// Turn off curent light
        //allCameras[(int)cameraTyp].turnOff();

        //// Turn on new light
        //cameraTyp = (InGameCameraType)((int)(CameraTypeCnt + cameraTyp + addValue) % CameraTypeCnt);
        //allCameras[(int)cameraTyp].turnOn();

    }

    public static BaseCamera getCurrentCamera()
    {
        return allCameras[(int)cameraTyp];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Up");
            changeCamera(1);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Down");
            changeCamera(-1);
        }

    }


}