using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevelState : MonoBehaviour
{

    public float wait;

    public void startGame()
    {
        GM.levelDetails.gameState = gameStates.Play;
        if (Events.BEFORE_THE_GAME_BEGIN != null)
            Events.BEFORE_THE_GAME_BEGIN();
        StartCoroutine(startGameWithWait());
    }

    public void restartGame()
    {
        GM.levelDetails.isFirstLoad = false;
        GM.loadLevel();
    }

    private IEnumerator startGameWithWait()
    {
        yield return new WaitForSeconds(wait);
        if (Events.START_GAME != null)
            Events.START_GAME();

    }
}
