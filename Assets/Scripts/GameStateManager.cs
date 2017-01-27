using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum gameStates
{
    PlaceMagnets,
    Play
}


public class GameStateManager : MonoBehaviour {

    public static gameStates gameState = gameStates.PlaceMagnets;
    public int levelInut;
    public static int level;
    public static bool switchLevel;

    void Start()
    {
        
        level = levelInut;
    }

    public static void ManageScenes()
    {
        SceneManager.LoadScene("level" + GameStateManager.level);
        if(switchLevel)
        {

        }
    }
}
