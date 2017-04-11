using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDimensions : MonoBehaviour {

    public static DeviceOrientation Screen_State;
    public static float widthUnit, heightUnit;

    private static ScreenDimensions instance = null;
    public static ScreenDimensions Instance
    {
        get { return instance; }
    }
    AudioSource a;
    private static int diff;
    // Awake is needed for innitializing screen params before start method
    void Awake()
    {
        Camera.main.aspect = Screen.height < Screen.width ? (float)Screen.height / Screen.width : (float)Screen.width / Screen.height;
        a = GetComponent<AudioSource>();
        if (a == null)
        {
            a = gameObject.AddComponent<AudioSource>();
        }

        a.clip = (AudioClip)Resources.Load("Sounds/" + "electricity", typeof(AudioClip));
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        
        Screen_State = Input.deviceOrientation;

        widthUnit = Screen.width / 10f;
        heightUnit = Screen.height / 10f;
        DontDestroyOnLoad(gameObject);
    }
}
