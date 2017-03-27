using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightManager : MonoBehaviour
{
    public static LightType lightTyp;
    public static List<BaseLight> allLights;

    void Start()
    {
        // Create the ligths for every scene
        allLights = new List<BaseLight>{ new NightLight(), new dayLight()};
    }

    public void changeLight(int addValue)
    {
        int lightTypeCnt = Enum.GetNames(typeof(LightType)).Length;

        // Turn off curent light
        allLights[(int)lightTyp].turnOff();

        // Turn on new light
        lightTyp = (LightType)((int)(lightTypeCnt + lightTyp + addValue) % lightTypeCnt);
        allLights[(int)lightTyp].turnOn();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Up");
            changeLight(1);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Down");
            changeLight(-1);
        }

    }


}