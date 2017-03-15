﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableSquareHandler
{
    public abstract bool isSquareAvailableAndClicked(SourcesLeftMangager sources,GameObject square);
    public abstract void manageSources(SourcesLeftMangager sources);
    public abstract GameObject getMagnetPrefab();
    public abstract void manageLight(GameObject square,GameObject light);
    public void playSound(GameObject sound)
    {
        sound.playSound();
    }
}

public class ClickOnEmpty : ClickableSquareHandler
{
    public override bool isSquareAvailableAndClicked(SourcesLeftMangager sources, GameObject square)
    {
        return GameStateManager.keys.select(square) && sources.remainMagnets();
    }

    public override void manageSources(SourcesLeftMangager sources)
    {
        sources.DecreaseSource();
    }

    public override GameObject getMagnetPrefab()
    {
        return Resources.Load<GameObject>("Prefabs/Squares/InMagnetSquare");
    }

    public override void manageLight(GameObject square,GameObject light)
    {
        Debug.Log(GameObject.Find("CurLevel/Lights").gameObject);
        GameObject g = GameObject.Instantiate(light, GameObject.Find("CurLevel/Lights/MagnetLights").transform);
        g.name = "light" + square.name;
        g.transform.localPosition = new Vector3(square.transform.localPosition.x,
                                                5,
                                                square.transform.localPosition.z);
    }
}

public class ClickOnMagnetic : ClickableSquareHandler
{
    public override bool isSquareAvailableAndClicked(SourcesLeftMangager sources, GameObject square)
    {
        return GameStateManager.keys.deselect(square);
    }

    public override void manageSources(SourcesLeftMangager sources)
    {
       
        sources.IncreaseSource();
    }

    public override GameObject getMagnetPrefab()
    {
        return Resources.Load<GameObject>("Prefabs/Squares/RegularSquare");
    }

    public override void manageLight(GameObject square, GameObject light)
    {
        Debug.Log("CurLevel/Lights/PlayLights" + square.name);
        GameObject.Find("CurLevel/Lights/MagnetLights/light" + square.name).GetComponent<LightOnPlay>().destroyLight();

    }
}