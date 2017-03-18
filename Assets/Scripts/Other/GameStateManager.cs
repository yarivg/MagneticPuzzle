using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    public int levelInput;
    public static int level = 1;
    public static bool switchLevel;
    public static BaseClicker keys;
    public static gameStates gameState;

    void Start()
    {
        gameState = gameStates.PlaceMagnets;
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                keys = new AndroidClicker();
                break;
            case RuntimePlatform.WindowsPlayer:
                keys = new ComputerClicker();
                break;
            case RuntimePlatform.WindowsEditor:
                keys = new ComputerClicker();
                break;
        }
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
