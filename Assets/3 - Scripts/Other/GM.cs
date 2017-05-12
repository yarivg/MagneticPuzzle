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

    void Awake()
    {
        _userPref = UserPreferences.Instance;
        if (_sceneLoader == null) throw new System.Exception("Scene Loader is not referenced!");
        
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
        
        //TODO: update dictionary
        _userPref.passLevel(levelIdentifier);
        //TODO: add logic when finish difficulty
        _sceneLoader.GoToLevel(GetDifficulty() + "-Level" + levelVal);
    }

    // should not be here
    public static void resetLevel()
    {
       // levelDetails.gameState = gameStates.PlaceMagnets;

        // TODO - ResetSqaures and magnets
        // Return ball to first position
        Events.INIT_LEVEL();

    }

    private string GetDifficulty()
    {
        return UserPreferences.Instance.GetTempInfo("Difficulty");
    }
}
