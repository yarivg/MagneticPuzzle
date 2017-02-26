using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithMagnet : MonoBehaviour
{

    public GameObject Magnet;
    private bool isGameRunning;

    void Awake()
    {
        isGameRunning = false;
        Events.START_GAME += enable;
        Events.STOP_GAME += disable;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (isGameRunning)
        {
            SquareCreator.createSquare(this.transform.localPosition, this.transform.lossyScale, Magnet, this.transform.parent.gameObject);
            Events.START_GAME -= enable;
            Events.STOP_GAME -= disable;
            Destroy(this.gameObject);
        }
    }

    void enable()
    {
        isGameRunning = true;
    }

    void disable()
    {
        isGameRunning = false;
    }
}