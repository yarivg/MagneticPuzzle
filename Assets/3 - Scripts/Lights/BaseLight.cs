using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseLight {
    protected string LightObjPath = "HUD/Lights/";
    protected string LightPrefabPath = "Prefabs/Lights/";
    protected LightType light;

    public BaseLight()
    {
        Events.BEFORE_THE_GAME_BEGIN += OnPlay;
        Events.STOP_GAME += onPlaceMagnets;
    }

    // Enable/disable current object
    public void turnOff(string pathInLight)
    {
        GameObject.Find(LightObjPath  + pathInLight).SetActive(false);
    }

    public void turnOn(string pathInLight)
    {
        GameObject.Find(LightObjPath + pathInLight).SetActive(true);
    }

    // Enable and disable play/place magnets lights
    private void OnPlay()
    {
        Debug.Log("progress play lights..");
        turnOn(gameStates.Play.ToString());
        turnOff(gameStates.PlaceMagnets.ToString());
    }

    private void onPlaceMagnets()
    {
        turnOn(gameStates.PlaceMagnets.ToString());
        turnOff(gameStates.Play.ToString());

    }



}

public class NightLight : BaseLight
{
    public GameObject pullMagnetLight;
    public GameObject pushMagnetLight;
    public NightLight()
    {
        light = LightType.nightLight;
        LightObjPath += "NightLights/";
        pullMagnetLight = (GameObject)Resources.Load(LightPrefabPath + "pullMagnetLight");
        pushMagnetLight = (GameObject)Resources.Load(LightPrefabPath + "pushMagnetLight");

        Events.CLICK_ON_EMPTY_SQUARE += addPullMagnetLight;
        Events.CLICK_ON_MAGNETIC_SQUARE += destroyMagnetLight;
        Events.COLLISION_WITH_MAGNET += changeToPushMagnetLight;

       
    }

    public void addPullMagnetLight(GameObject square)
    {
        string PathToCreateMagnet = LightObjPath + "GenericLights";
        GameObject g = GameObject.Instantiate(pullMagnetLight, GameObject.Find(PathToCreateMagnet).transform);
        g.name = "light" + square.name;
        g.transform.localPosition = new Vector3(square.transform.localPosition.x,
                                                  5,
                                                square.transform.localPosition.z);


        //Debug.Log("local:"+g.transform.localPosition);
        //Debug.Log("global:" + g.transform.position);
    }

    public void changeToPushMagnetLight(GameObject square)
    {
        string PathToCreateMagnet = LightObjPath + "GenericLights";
        GameObject.Destroy(GameObject.Find(PathToCreateMagnet + "/light" + square.name));
        GameObject g = GameObject.Instantiate(pushMagnetLight, GameObject.Find(PathToCreateMagnet).transform);
        g.GetComponent<Light>().enabled = true;
        g.name = "light" + square.name;
        g.transform.localPosition = new Vector3(square.transform.localPosition.x,
                                                5,
                                                square.transform.localPosition.z);
    }

    public void destroyMagnetLight(GameObject square)
    {
        string PathToCreateMagnet = LightObjPath + "GenericLights";
        GameObject.Destroy(GameObject.Find(PathToCreateMagnet + "/light" + square.name).gameObject);
    }

    public void changeLightColor(GameObject square)
    {
        GameObject.Find(LightObjPath + "Play/" + "light" + square.name).GetComponent<Light>().color = new Color(50, 50, 50);
    }
}

public class dayLight : BaseLight
{
    public dayLight()
    {
        light = LightType.dayLight;
        LightObjPath += "DayLights/";
    }
}
