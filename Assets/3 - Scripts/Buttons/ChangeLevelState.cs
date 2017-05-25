using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeLevelState : MonoBehaviour
{

    public float wait;
    private GM gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag(Tags.God.ToString()).GetComponent<GM>();
    }

    public void startGame()
    {
        //gameManager.levelDetails.gameState = gameStates.Play;
        if (Events.BEFORE_THE_GAME_BEGIN != null)
            Events.BEFORE_THE_GAME_BEGIN();
        StartCoroutine(startGameWithWait());
    }

    public void restartGame()
    {
        SceneLoader _sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        _sceneLoader.changeScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator startGameWithWait()
    {
        yield return new WaitForSeconds(wait);
        if (Events.START_GAME != null)
            Events.START_GAME();

    }
}
