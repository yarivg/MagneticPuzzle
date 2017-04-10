using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseCamera
{
    protected string CameraObjPath = "HUD/Cameras/";
    protected string CameraPrefabPath = "Prefabs/Cameras/";
    protected InGameCameraType camera;
    private GameObject cam;

    public BaseCamera(InGameCameraType camera)
    {
        this.camera = camera;
        cam = GameObject.Find(CameraObjPath + camera.ToString() + "/RealCamera");
    }

    private void UpdateCameraStatus(bool enable)
    {
        cam = GameObject.Find(CameraObjPath + camera.ToString() + "/RealCamera");
        Debug.Log(cam);
        cam.GetComponent<Camera>().enabled = enable;
        cam.GetComponent<AudioListener>().enabled = enable;
    }

    public void turnOff()
    {
        UpdateCameraStatus(false);
    }

    public void turnOn()
    {
        UpdateCameraStatus(true);
    }

    public void MakeFollow()
    {
        cam.GetComponent<CameraController>().enabled = !cam.GetComponent<CameraController>().enabled;
    }

}

public class NightCamera : BaseCamera
{
    public NightCamera():
        base(InGameCameraType.nightCamera)
    {

    }
}

public class DayCamera : BaseCamera
{
    public DayCamera():
        base(InGameCameraType.dayCamera)
    {

    }
}