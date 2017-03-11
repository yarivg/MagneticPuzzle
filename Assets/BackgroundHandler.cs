using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour {

    public Sprite portraitBackgrond;
    public Sprite landspaceBackground;

    // Use this for initialization
    void Start () {
		if(ScreenDimensions.Screen_State == SCREEN_STATE.PORTARAIT)
        {
            GetComponent<SpriteRenderer>().sprite = portraitBackgrond;
        } else if (ScreenDimensions.Screen_State == SCREEN_STATE.LANDSPACE)
        {
            GetComponent<SpriteRenderer>().sprite = landspaceBackground;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
