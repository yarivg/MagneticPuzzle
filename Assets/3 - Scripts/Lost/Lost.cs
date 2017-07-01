using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Lost
{
    public static bool saveMagnetPositions = true;
    public static List<Vector3> MagnetsPositions = new List<Vector3>();

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
        Debug.Log("ball lost " + balls.Length);

        lostData = new List<LostByFallData>();
        foreach (GameObject ball in balls)
        {
            lostData.Add(new LostByFallData(ball));
        }

        MagnetsPositions = new List<Vector3>();

    }

    public override bool isLost()
    {

        for (int i = 0; i < lostData.Count;i++) 
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
        Debug.Log("ball lost");
        if (saveMagnetPositions)
        {
            foreach (Transform square in GameObject.FindGameObjectWithTag(Tags.SquareManager.ToString()).transform)
            {
                if (square.tag == Tags.MagneticFloor.ToString())
                {
                    MagnetsPositions.Add(square.localPosition);
                }
            }
        }

        // Write to log / db

        // Restart Game
        ChangeLevelState _levelState = GameObject.FindObjectOfType<ChangeLevelState>();
        _levelState.restartGame();
    }
}

public class LostByRestart : Lost
{
    public Button restartButton;

    public LostByRestart()
    {
        restartButton = GameObject.FindGameObjectWithTag(Tags.UI.ToString()).FindObject(Tags.RestartButton.ToString()).GetComponent<Button>();
        restartButton.onClick.AddListener(() => { executeInLost(); });
        Debug.Log(restartButton);
        Debug.Log("click:"+restartButton.onClick.GetPersistentEventCount());
    }

    public override void executeInLost()
    {
        Debug.Log("lost by reset");
        if (saveMagnetPositions)
        {
            Debug.Log("save magnets positions..");
            foreach (Transform square in GameObject.FindGameObjectWithTag(Tags.SquareManager.ToString()).transform)
            {
                if (square.tag == Tags.MagneticFloor.ToString())
                {
                    MagnetsPositions.Add(square.localPosition);
                }
            }
            Debug.Log("magnet squares number:" + MagnetsPositions.Count);
        }

        // Write to log / db

        // Restart Game
        ChangeLevelState _levelState = GameObject.FindObjectOfType<ChangeLevelState>();
        _levelState.restartGame();
    }

    public override bool isLost()
    {
        return false;
    }
}
