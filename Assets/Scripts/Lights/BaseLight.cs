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
    public GameObject magnetLight;
    public NightLight()
    {
        light = LightType.nightLight;
        LightObjPath += "NightLights/";
        magnetLight = (GameObject)Resources.Load(LightPrefabPath + "MagnetLight");
        Events.CLICK_ON_EMPTY_SQUARE += addMagnetLight;
        Events.CLICK_ON_MAGNETIC_SQUARE += destroyMagnetLight;
    }

    public void addMagnetLight(GameObject square)
    {
        string PathToCreateMagnet = LightObjPath + gameStates.Play;
        GameObject g = GameObject.Instantiate(magnetLight, GameObject.Find(PathToCreateMagnet).transform);
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
}
