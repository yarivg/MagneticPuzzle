using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{

    // Depend to lost
    private const float MIN_SPEED_TO_DIE = 0.35f;
    private const int MAX_FRAMES_WITH_SLOW_SPEED = 90;
    private const float LOST_VALUE_Y = -5;

    private int framesWithSlowSpeed;
    private Vector3 prevPosition;

    void Awake()
    {
        framesWithSlowSpeed = 0;
        prevPosition = transform.position;
        Events.START_GAME += enableBallMovementAbillity;
    }

    void FixedUpdate()
    {
        DetectIfLost();
    }

    private void DetectIfLost()
    {
        float speed = (transform.position - prevPosition).magnitude / Time.deltaTime;
        prevPosition = transform.position;

        framesWithSlowSpeed = speed < MIN_SPEED_TO_DIE ? framesWithSlowSpeed + 1 : 0;

        if ((transform.position.y < LOST_VALUE_Y || framesWithSlowSpeed > MAX_FRAMES_WITH_SLOW_SPEED))
        {
            // *** Change it to restart function ***
            GameStateManager.switchLevel = false;
            GameStateManager.loadScene();
        }
    }

    void enableBallMovementAbillity()
    {
        this.enabled = true;
        this.gameObject.setKinematic(false);
    }
}