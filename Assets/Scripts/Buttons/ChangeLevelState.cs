using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevelState : MonoBehaviour {

    public float wait;
    public GameObject playButton;
    public Sprite playImage;
    public Sprite restartImage;

    //void Awake()
   // {
      //  Events.BEFORE_THE_GAME_BEGIN += disable;
 //   }

    // *** DO IT WITH UI FUNCTION ***
    //void OnMouseOver()
    //{

    //    if (GameStateManager.keys.select(gameObject))
    //    {
    //        startGame();
    //    }
    //}

    //void disable()
    //{
    //    gameObject.GetComponent<BoxCollider>().enabled = false;
    //    gameObject.GetComponent<MeshRenderer>().enabled = false;
    //    //this.gameObject.SetActive(false);
    //}

    //void enable()
    //{
    //    gameObject.GetComponent<MeshCollider>().enabled = true;
    //    gameObject.GetComponent<MeshRenderer>().enabled = true;
    //    //  this.gameObject.SetActive(true);
    //}

    public void startGame()
    {
        if(GameStateManager.gameState != gameStates.Play)
        {
            playButton.GetComponent<Image>().sprite = restartImage;
            GameStateManager.gameState = gameStates.Play;
            if (Events.BEFORE_THE_GAME_BEGIN != null)
                Events.BEFORE_THE_GAME_BEGIN();
            StartCoroutine(startGameWithWait());
        } else
        {
            GameStateManager.switchLevel = false;
            GameStateManager.loadScene();
        }

    }

    public void restartGame()
    {
       GameStateManager.switchLevel = false;
       GameStateManager.loadScene();
    }

    IEnumerator startGameWithWait()
    {
        yield return new WaitForSeconds(wait);

        if (Events.START_GAME != null)
            Events.START_GAME();
        
    }
}
