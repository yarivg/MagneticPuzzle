using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour {

    public float wait;

    void Awake()
    {
      //  Events.BEFORE_THE_GAME_BEGIN += disable;
        Events.STOP_GAME += enable;
    }

    void OnMouseOver()
    {

        if (GameStateManager.keys.select(gameObject))
        {
            startGame();
        }
    }

    public void startGame()
    {
        GameStateManager.gameState = gameStates.Play;
        if (Events.BEFORE_THE_GAME_BEGIN != null)
            Events.BEFORE_THE_GAME_BEGIN();
        StartCoroutine(startGameWithWait());
    }

    public void restartGame()
    {
       GameStateManager.switchLevel = false;
       GameStateManager.loadScene();
    }

    void disable()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        //this.gameObject.SetActive(false);
    }

    void enable()
    {
        gameObject.GetComponent<MeshCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        //  this.gameObject.SetActive(true);
    }


    IEnumerator startGameWithWait()
    {
        yield return new WaitForSeconds(wait);

        if (Events.START_GAME != null)
            Events.START_GAME();
        
    }
}
