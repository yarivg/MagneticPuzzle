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

    // *** Need to be deleted - all the load levels need to be in scene loader ***
    public static void loadLevel()
    {
        Events.restartEvents();
        string difficulty = UserPreferences.Instance.GetTempInfo("Difficulty") != null ? UserPreferences.Instance.GetTempInfo("Difficulty") : "Easy";
        //  Debug.Log(string.Format("Loading scene - {0}", difficulty + "-level" + level));

        // TODO - this line should be in production
        //SceneManager.LoadScene(difficulty + "-level" + level);

        // More easy.. TODO - this line should be in production

        //  SceneManager.LoadScene(levelDetails.levelName);

        // For debugging
        SceneManager.LoadScene("LevelDesignTemplate");
        
    }

    // should not be here
    public static void resetLevel()
    {
       // levelDetails.gameState = gameStates.PlaceMagnets;

        // TODO - ResetSqaures and magnets
        // Return ball to first position
        Events.INIT_LEVEL();

    }
}
