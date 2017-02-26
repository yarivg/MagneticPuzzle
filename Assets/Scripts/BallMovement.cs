using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{

    private float speed;

    // Depend to lost
    private const float MIN_SPEED_TO_DIE = 0.35f;
    private const int MAX_FRAMES_WITH_SLOW_SPEED = 90;
    private const float LOST_VALUE_Y = -5;
    private int framesWithSlowSpeed;
    private Vector3 prevPosition;

    void Start()
    {
        framesWithSlowSpeed = 0;
        prevPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (GameStateManager.gameState == gameStates.Play)
        {
            DetectIfLost();
            GetComponent<Rigidbody>().isKinematic = false;
        }
        else if (GameStateManager.gameState == gameStates.PlaceMagnets)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void DetectIfLost()
    {
        speed = (transform.position - prevPosition).magnitude / Time.deltaTime;
        prevPosition = transform.position;

        framesWithSlowSpeed = speed < MIN_SPEED_TO_DIE ? framesWithSlowSpeed + 1 : 0;

        if ((transform.position.y < LOST_VALUE_Y || framesWithSlowSpeed > MAX_FRAMES_WITH_SLOW_SPEED))
        {
            GameStateManager.gameState = gameStates.PlaceMagnets;
            GameStateManager.switchLevel = false;
            GameStateManager.loadScene();
        }
    }
}