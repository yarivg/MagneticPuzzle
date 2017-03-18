using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{

    void Awake()
    {
        Events.BEFORE_THE_GAME_BEGIN += enable;
        Events.STOP_GAME += disable;
        this.gameObject.SetActive(false);

    }

    void OnMouseOver()
    {
        if (GameStateManager.keys.select(gameObject))
        {
            GameStateManager.switchLevel = false;
            GameStateManager.loadScene();
        }
    }

    void disable()
    {
        this.gameObject.SetActive(false);
    }

    void enable()
    {
        this.gameObject.SetActive(true);
    }
}
