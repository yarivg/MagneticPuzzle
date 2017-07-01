using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnSquare : MonoBehaviour
{
    private AudioSource pickupSound;
    public ClickableSquareHandler manager;
    private SourcesLeftManager source;
    void Start()
    {
        source = FindObjectOfType<SourcesLeftManager>();
        pickupSound = GameObject.FindGameObjectWithTag(Tags.Pickup.ToString()).GetComponent<AudioSource>();

        if (gameObject.tag == Tags.Floor.ToString())
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
        bool isSquareCreated = false;
        if(GM.keys.select(this.gameObject))
        {
            if(gameObject.tag == Tags.MagneticFloor.ToString())
            {
                isSquareCreated = SquareHandler.Instance.createRegularSquare(this.transform.localPosition, true, true);
            }
            if (gameObject.tag == Tags.Floor.ToString())
            {
                isSquareCreated = SquareHandler.Instance.createInMagnetSquare(this.transform.localPosition, true, true);
            }
            if (isSquareCreated)
            {
                    Events.BEFORE_THE_GAME_BEGIN -= disable;
                    Events.STOP_GAME -= enable;
                Destroy(this.gameObject);
            }
        }

        //if (manager.isSquareAvailableAndClicked(source, this.gameObject))
        //{
        //    Debug.Log(this.transform.localPosition);
        //    SquareCreator.createSquare(this.transform.localPosition, this.transform.lossyScale, manager.getMagnetPrefab(), this.transform.parent.gameObject);
        //    manager.manageSources(source);
        //    manager.playSound(pickupSound);
        //    manager.execClickEvent(gameObject);


        //    Events.BEFORE_THE_GAME_BEGIN -= disable;
        //    Events.STOP_GAME -= enable;
        //    Destroy(this.gameObject);

        //}
    }

    void createMagnetSquare()
    {

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