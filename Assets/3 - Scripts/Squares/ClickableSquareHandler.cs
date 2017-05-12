using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableSquareHandler
{
    public abstract bool isSquareAvailableAndClicked(SourcesLeftManager sources,GameObject square);
    public abstract void manageSources(SourcesLeftManager sources);
    public abstract GameObject getMagnetPrefab();
    public abstract void manageLight(GameObject square,GameObject light);
    public abstract void execClickEvent(GameObject gameObject);

    public void playSound(AudioSource sound)
    {
        sound.Play();
    }
}

public class ClickOnEmpty : ClickableSquareHandler
{
    public override bool isSquareAvailableAndClicked(SourcesLeftManager sources, GameObject square)
    {
        return GM.keys.select(square) && sources.remainMagnets();
    }

    public override void manageSources(SourcesLeftManager sources)
    {
        sources.DecreaseSource();
    }

    public override GameObject getMagnetPrefab()
    {
        return Resources.Load<GameObject>("Prefabs/Squares/InMagnetSquare");
    }

    public override void manageLight(GameObject square,GameObject light)
    {
        GameObject g = GameObject.Instantiate(light, GameObject.Find("CurLevel/Lights/MagnetLights").transform);
        g.name = "light" + square.name;
        g.transform.localPosition = new Vector3(square.transform.localPosition.x,
                                                5,
                                                square.transform.localPosition.z);
        Transform t;
        //Quaternion.lo
            //t.look
    }

    public override void execClickEvent(GameObject square)
    {
        if (Events.CLICK_ON_EMPTY_SQUARE != null)
            Events.CLICK_ON_EMPTY_SQUARE(square);
    }
}

public class ClickOnMagnetic : ClickableSquareHandler
{
    public override bool isSquareAvailableAndClicked(SourcesLeftManager sources, GameObject square)
    {
        return GM.keys.deselect(square);
    }

    public override void manageSources(SourcesLeftManager sources)
    {
       
        sources.IncreaseSource();
    }

    public override GameObject getMagnetPrefab()
    {
        return Resources.Load<GameObject>("Prefabs/Squares/RegularSquare");
    }

    public override void manageLight(GameObject square, GameObject light)
    {

    }


    public override void execClickEvent(GameObject square)
    {
        if (Events.CLICK_ON_MAGNETIC_SQUARE != null)
            Events.CLICK_ON_MAGNETIC_SQUARE(square);
    }
}