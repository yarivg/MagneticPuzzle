using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * Its a level manager script 
 * Relevant to restart , play and etc
 * keys little wierd here
 * */
 
public class GM : MonoBehaviour {

    public InLevelData levelDetailsInput;
    public static InLevelData levelDetails;
    public static BaseClicker keys;
    
    void Awake()
    {
      
        levelDetails = levelDetailsInput;
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
    }

    public static void loadLevel()
    {
        Events.restartEvents();
        string difficulty = UserPreferences.Instance.GetValue("Difficulty") != null ? UserPreferences.Instance.GetValue("Difficulty") : "Easy";
        //  Debug.Log(string.Format("Loading scene - {0}", difficulty + "-level" + level));

        // TODO - this line should be in production
        //SceneManager.LoadScene(difficulty + "-level" + level);

        // More easy.. TODO - this line should be in production

        SceneManager.LoadScene(levelDetails.levelName);

        // For debugging
        //SceneManager.LoadScene("LevelDesignTemplate");
        
    }

    public static void resetLevel()
    {
       // levelDetails.gameState = gameStates.PlaceMagnets;

        // TODO - ResetSqaures and magnets
        // Return ball to first position
        Events.INIT_LEVEL();

    }

    // **** SHOULD NOT BE HERE ****
    private void Update()
    {
        if (keys != null && UserPreferences.Instance.LastScene != SceneManager.GetActiveScene().name && keys.is_back_button_pressed())
        {
            Events.BACK_BUTTON_PRESSED();
        }
    }
}
