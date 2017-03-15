using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour {

    void Awake()
    {
        Events.BEFORE_THE_GAME_BEGIN += movePlay;
        Events.START_GAME += disable;
        Events.STOP_GAME += enable;
    }

    void OnMouseOver()
    {

        if (GameStateManager.keys.select(gameObject))
        {
            if (Events.BEFORE_THE_GAME_BEGIN != null)
                Events.BEFORE_THE_GAME_BEGIN();
            StartCoroutine(startGameWithWait(2));
            

        }
    }

    void movePlay()
    {
        this.gameObject.transform.GetComponent<Transform>().position = new Vector3(1000, 1000, 1000);
    }

    void disable()
    {
        this.gameObject.SetActive(false);
    }

    void enable()
    {
        this.gameObject.SetActive(true);
    }

    IEnumerator startGameWithWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (Events.START_GAME != null)
            Events.START_GAME();
    }
}
