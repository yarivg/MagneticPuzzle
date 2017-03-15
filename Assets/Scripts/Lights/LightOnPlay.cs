using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnPlay : MonoBehaviour {

    public bool turnOn;

	// Use this for initialization
	void Start () {
        if (turnOn)
        {
            Events.BEFORE_THE_GAME_BEGIN += enable;
            Events.STOP_GAME += disable;
        }
        else
        {
            Events.BEFORE_THE_GAME_BEGIN += disable;
            Events.STOP_GAME += enable;
        }
        	
	}

    void enable()
    {
        gameObject.GetComponent<Light>().enabled = true;
    }

    void disable()
    {
        gameObject.GetComponent<Light>().enabled = false;
    }

    public void destroyLight()
    {
        Events.BEFORE_THE_GAME_BEGIN -= enable;
        Events.STOP_GAME -= disable;
        Destroy(this.gameObject);
    }
}
