using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseLight {
    protected string LightObjPath = "CurLevel/Lights/";
    protected string LightPrefabPath = "Prefabs/Lights/";
    protected LightType light;

    public BaseLight()
    {
        Events.BEFORE_THE_GAME_BEGIN += OnPlay;
        Events.STOP_GAME += onPlaceMagnets;
    }

    private void TurnAllLightInPath(gameStates gs,bool turnOn)
    {
        foreach(Transform child in GameObject.Find(LightObjPath + gs.ToString()).transform)
        {
            child.GetComponent<Light>().enabled = turnOn;
        } 
    }

    public void turnOff()
    {
        TurnAllLightInPath(GameStateManager.gameState,false);
    }

    public void turnOn()
    {
        TurnAllLightInPath(GameStateManager.gameState, true);
    }

    private void OnPlay()
    {
        bool turnOnPlayLight = light == LightManager.lightTyp;
        bool turnOnPlaceMagnetsLights = false;
        TurnAllLightInPath(gameStates.Play, turnOnPlayLight);
        TurnAllLightInPath(gameStates.PlaceMagnets, turnOnPlaceMagnetsLights);
    }

    private void onPlaceMagnets()
    {
        bool turnOnPlaceMagnetsLights = light == LightManager.lightTyp;
        bool turnOnPlayLight = false;
        TurnAllLightInPath(gameStates.Play, turnOnPlayLight);
        TurnAllLightInPath(gameStates.PlaceMagnets, turnOnPlaceMagnetsLights);
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
        string PathToCreateMagnet = LightObjPath + gameStates.Play;
        GameObject g = GameObject.Instantiate(pullMagnetLight, GameObject.Find(PathToCreateMagnet).transform);
        g.name = "light" + square.name;
        g.transform.localPosition = new Vector3(square.transform.localPosition.x,
                                                5,
                                                square.transform.localPosition.z);
    }

    public void changeToPushMagnetLight(GameObject square)
    {
        string PathToCreateMagnet = LightObjPath + gameStates.Play;
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
        string PathToCreateMagnet = LightObjPath + gameStates.Play;
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
