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

    void Awake()
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
        string difficulty = UserPreferences.Instance.GetValue("Difficulty") != null ? UserPreferences.Instance.GetValue("Difficulty") : "Easy";
        Debug.Log(string.Format("Loading scene - {0}", difficulty + "-level" + level));
        SceneManager.LoadScene(difficulty + "-level" + level);
    }

    private void Update()
    {
        if (keys != null && UserPreferences.Instance.LastScene != SceneManager.GetActiveScene().name && keys.is_back_button_pressed())
        {
            Events.BACK_BUTTON_PRESSED();
        }
    }
}
