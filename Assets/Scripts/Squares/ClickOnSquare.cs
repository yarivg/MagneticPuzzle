﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnSquare : MonoBehaviour
{
    public GameObject light; 
    private GameObject Magnet;
    private GameObject pickupSound;
    public ClickableSquareHandler manager;
    private SourcesLeftMangager source;
    void Start()
    {
        source = GameObject.Find("CurLevel").transform.Find("HUD/SourceLeftText/SourceManager").GetComponent<SourcesLeftMangager>();
        pickupSound = GameObject.FindGameObjectWithTag(Tags.Pickup.ToString());

        if(gameObject.tag == Tags.Floor.ToString())
        {
            manager = new ClickOnEmpty();
        }

        if (gameObject.tag == Tags.MagneticFloor.ToString())
        {
            manager = new ClickOnMagnetic();
        }
        Events.BEFORE_THE_GAME_BEGIN += disable;
        Events.STOP_GAME += enable;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (manager.isSquareAvailableAndClicked(source,this.gameObject))
        {
            SquareCreator.createSquare(this.transform.localPosition, this.transform.lossyScale,manager.getMagnetPrefab(), this.transform.parent.gameObject);
            manager.manageSources(source);
            manager.playSound(pickupSound);
            manager.manageLight(gameObject,light);
            Events.BEFORE_THE_GAME_BEGIN -= disable;
            Events.STOP_GAME -= enable;
            Destroy(this.gameObject);

        }
    }

    void enable()
    {
        this.enabled = true;
    }

    void disable()
    {
        this.enabled = false;
    }
}