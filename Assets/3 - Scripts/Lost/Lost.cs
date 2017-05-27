using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lost
{
    public abstract bool isLost();
    public abstract void executeInLost();
}

public class LostByFall : Lost {

    GameObject[] balls;

    private const float MIN_SPEED_TO_DIE = 0.35f;
    private const int MAX_FRAMES_WITH_SLOW_SPEED = 90;
    private const float LOST_VALUE_Y = -5;

    private List<LostByFallData> lostData;

    public LostByFall(GameObject[] balls)
    {
        lostData = new List<LostByFallData>();
        foreach (GameObject ball in balls)
        {
            lostData.Add(new LostByFallData(ball));
        }
    }

    public override bool isLost()
    {
        for(int i = 0; i < lostData.Count;i++) 
        {
            LostByFallData data = lostData[i];
            float speed = (data.ball.transform.position - data.prevPosition).magnitude / Time.deltaTime;
            data.prevPosition = data.ball.transform.position;
            data.frameWithSlowSpeed = speed < MIN_SPEED_TO_DIE ? data.frameWithSlowSpeed + 1 : 0;
            if ((data.ball.transform.position.y < LOST_VALUE_Y || data.frameWithSlowSpeed > MAX_FRAMES_WITH_SLOW_SPEED))
            {
                return true;
            }
        }
        return false;
    }

    public override void executeInLost()
    {
        Debug.Log("lost");

        // Write to log / db

        // Restart Game
        ChangeLevelState _levelState = GameObject.FindObjectOfType<ChangeLevelState>();
        _levelState.restartGame();
    }
}
