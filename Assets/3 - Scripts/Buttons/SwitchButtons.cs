using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Events.BEFORE_THE_GAME_BEGIN += onPlay;
	}

    void onPlay()
    {
        gameObject.transform.FindChild("Play").GetComponent<Image>().enabled = false;
        gameObject.transform.FindChild("Play").GetComponent<Button>().enabled = false;
        gameObject.transform.FindChild("Restart").GetComponent<Image>().enabled = true;
        gameObject.transform.FindChild("Restart").GetComponent<Button>().enabled = true;
    }

}
