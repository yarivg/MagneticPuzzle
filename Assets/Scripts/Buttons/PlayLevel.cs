using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour {

    void Awake()
    {
        Events.START_GAME += disable;
        Events.STOP_GAME += enable;
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown((int)Mouseclicks.leftClick))
        {
            if(Events.START_GAME != null)
                Events.START_GAME();
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
