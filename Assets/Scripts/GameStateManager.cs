using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    public int levelInput;
    public static int level = 1;
    public static bool switchLevel;
    public static gameStates gameState = gameStates.PlaceMagnets;

    void Start()
    {
        // If the user enter input , use his input 
        // Important to use this for menu
        level = levelInput == 0 ? level : levelInput;
    }

    public static void loadScene()
    {
        Events.restartEvents();
        SceneManager.LoadScene("level" + GameStateManager.level);
    }
}
