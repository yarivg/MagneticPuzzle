using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    public int levelInput;
    public static int level = 1;
    public static bool switchLevel;
    public static gameStates gameState = gameStates.PlaceMagnets;
    public static BaseClicker keys;

    void Awake()
    {
        Debug.Log(UserPreferences.Instance);
        Camera.main.aspect = 480f / 800f;

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
        if (keys != null && UserPreferences.Instance.LastScene != SceneManager.GetActiveScene().name && keys.is_back_button_pressed())
        {
            Debug.Log(string.Format("Last: {0}, Current: {1}", UserPreferences.Instance.LastScene, SceneManager.GetActiveScene().name));

            Events.BACK_BUTTON_PRESSED();
        }
    }
}
