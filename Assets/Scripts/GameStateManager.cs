using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameStates
{
    PlaceMagnets,
    Play
}


public class GameStateManager : MonoBehaviour {

    public static gameStates gameState = gameStates.PlaceMagnets;
    public static string level;
    public static Vector3[] ballPositions = { new Vector3(0,0.5f,0), new Vector3(31.37f, 0.5f, 1.5f) };
    public static Vector3[] camerasPositions = { new Vector3(0, 20.5f, 0), new Vector3(31.85f, 20f, 20.5f) };

    public void Start()
    {
        gameState = gameStates.PlaceMagnets;
        level = "level1";
    
    }
}
