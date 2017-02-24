using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithMagnet : MonoBehaviour
{

    public GameObject Magnet;
    private bool Alive;

    void Awake()
    {
        Alive = false;
        Events.START_GAME += enable;
        Events.STOP_GAME += disable;

    }


    // Update is called once per frame
    void OnMouseOver()
    {
        if (Alive)
        {
            SquareCreator.createSquare(this.transform.position, this.transform.lossyScale, Magnet, this.transform.parent.gameObject);
            Events.START_GAME -= enable;
            Events.STOP_GAME -= disable;
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