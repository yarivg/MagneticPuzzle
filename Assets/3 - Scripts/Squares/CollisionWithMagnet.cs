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
            Debug.Log("local position:" + this.transform.localPosition);
            SquareHandler.Instance.createOutMagnetSquare(this.transform.localPosition, false, true);
            Events.START_GAME -= enable;
            Events.STOP_GAME -= disable;
           // Events.COLLISION_WITH_MAGNET(this.gameObject);
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