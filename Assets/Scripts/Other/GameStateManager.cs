﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void BACK_BUTTON_PRESSED();

public class GameStateManager : MonoBehaviour {

    public int levelInput;
    public static int level = 1;
    public static bool switchLevel;
    public static gameStates gameState = gameStates.PlaceMagnets;
    public static BaseClicker keys;

    void Awake()
    {
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

    private void Update()
    {
        if (UserPreferences.Instance.LastScene != SceneManager.GetActiveScene().name && keys != null)
        {
            if (keys.is_back_button_pressed())
            {
                Events.BACK_BUTTON_PRESSED();
            }
        }
    }
}
