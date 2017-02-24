using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMagnet : MonoBehaviour
{

    public GameObject Magnet;
    public GameObject pickupSound;
    private bool Alive;

    void Start()
    {
        Alive = false;
        Events.START_GAME += disable;
        Events.STOP_GAME += enable;

    }


    // Update is called once per frame
    void OnMouseOver()
    {
        SourcesLeftMangager source = GameObject.Find("Level" + GameStateManager.level.ToString()).transform.Find("HUD/SourceLeftText/SourceManager").GetComponent<SourcesLeftMangager>();
        if (Input.GetMouseButtonDown((int)Mouseclicks.rightClick) && source.remainMagnets() && Alive)
        {
            SquareCreator.createSquare(this.transform.position, this.transform.lossyScale, Magnet, this.transform.parent.gameObject);
            source.DecreaseSource();
            pickupSound.gameObject.PlaySound();

            Events.START_GAME -= disable;
            Events.STOP_GAME -= enable;

            Destroy(this);

        }
    }

    void enable()
    {
        Alive = true;
    }

    void disable()
    {
        Alive = false;
    }
}