using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{

    void Awake()
    {
        Events.START_GAME += enableBallMovementAbillity;
    }

    void enableBallMovementAbillity()
    {
        this.gameObject.setKinematic(false);
    }
}