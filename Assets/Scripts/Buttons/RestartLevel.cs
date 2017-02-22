using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{

    void Awake()
    {
        Events.START_GAME += enable;
        Events.STOP_GAME += disable;
        this.gameObject.SetActive(false);

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown((int)Mouseclicks.leftClick))
        {
            GameStateManager.switchLevel = false;
            Events.STOP_GAME = Events.START_GAME = null;
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
