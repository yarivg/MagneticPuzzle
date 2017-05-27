using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightManager : MonoBehaviour
{
    public static LightType lightTyp;
    public List<BaseLight> allLights;

    void Start()
    {
        if (allLights == null)
        {
            allLights = new List<BaseLight> { new NightLight(), new dayLight() };
        }
    }

    public void changeLight(int addValue)
    {

        // Use this function before start call..
        if (allLights == null)
        {
            allLights = new List<BaseLight> { new NightLight(), new dayLight() };
        }

        int lightTypeCnt = Enum.GetNames(typeof(LightType)).Length;

        Debug.Log("changing the light:" + lightTyp);


        // Turn off curent light
        Debug.Log(allLights);
         allLights[(int)lightTyp].turnOff("");

        // Turn on new light
        lightTyp = (LightType)((int)(addValue)); //(LightType)((int)(lightTypeCnt + lightTyp + addValue) % lightTypeCnt);
        allLights[(int)lightTyp].turnOn("");

    }
}