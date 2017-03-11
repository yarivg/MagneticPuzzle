using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDimensions : MonoBehaviour {

    public static SCREEN_STATE Screen_State;
    public static float widthUnit, heightUnit;

    private static ScreenDimensions instance = null;
    public static ScreenDimensions Instance
    {
        get { return instance; }
    }

    // Awake is needed for innitializing screen params before start method
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        Screen_State = Screen.height > Screen.width ? SCREEN_STATE.PORTARAIT : SCREEN_STATE.LANDSPACE;

        widthUnit = Screen.width / 10f;
        heightUnit = Screen.height / 10f;
        
        DontDestroyOnLoad(gameObject);
    }
}
