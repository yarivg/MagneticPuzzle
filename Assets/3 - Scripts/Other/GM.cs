using System;
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
    public LevelIdentifier levelIdentifier;
    public static BaseClicker keys;

    private UserPreferences _userPref;
    public SceneLoader _sceneLoader;
    public static bool DEBUG_MODE = false;

    void Awake()
    {
        _userPref = UserPreferences.Instance;
        if (_sceneLoader == null) throw new System.Exception("Scene Loader is not referenced!");

        string keysType;
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                keys = new AndroidClicker();
                keysType = "Android";
                break;
            case RuntimePlatform.WindowsPlayer:
                keys = new ComputerClicker();
                keysType = "Windows";
                break;
            case RuntimePlatform.WindowsEditor:
                keys = new ComputerClicker();
                keysType = "Windows";
                break;
            default:
                keysType = null;
                break;
        }
        if(DEBUG_MODE)
        {
            Debug.Log("The game keys created for:" + keysType);
            if(keysType == null)
            {
                throw new Exception("Keys not initalize!");
            }
        }
    }

    //// *** Need to be deleted - all the load levels need to be in scene loader ***
    //public static void loadLevel()
    //{
    //    Events.restartEvents();
    //    //  Debug.Log(string.Format("Loading scene - {0}", difficulty + "-level" + level));

    //    // TODO - this line should be in production
    //    //SceneManager.LoadScene(difficulty + "-level" + level);

    //    // More easy.. TODO - this line should be in production

    //    SceneManager.LoadScene(levelDetails.levelName);

    //    // For debugging
    //    //SceneManager.LoadScene("LevelDesignTemplate");
        
    //}

    public void nextLevel()
    {
        string levelVal = (levelIdentifier.levelNumber + 1).ToString();
        
        if(DEBUG_MODE)
        {
            Debug.Log("Pass level " + levelVal + " and go to next level" + GetDifficulty() + "-Level" + levelVal);
        }

        //TODO: update dictionary
        _userPref.passLevel(levelIdentifier);
        //TODO: add logic when finish difficulty
        _sceneLoader.GoToLevel(GetDifficulty() + "-Level" + levelVal);
    }

    // should not be here
    public static void resetLevel()
    {
        if (DEBUG_MODE)
        {
            Debug.Log("Restart current level..");
        }

        // levelDetails.gameState = gameStates.PlaceMagnets;

        // TODO - ResetSqaures and magnets
        // Return ball to first position
        Events.INIT_LEVEL();

    }

    private string GetDifficulty()
    {
        string difficulty = UserPreferences.Instance.GetTempInfo("Difficulty");
     //   if (DEBUG_MODE)
        {
            Debug.Log("Current difficulty:" + difficulty);

            if(difficulty == null)
            {
                Debug.LogWarning("Difficulty is null!");
                return "Easy";
            }
        }


        return UserPreferences.Instance.GetTempInfo("Difficulty");
    }
}
