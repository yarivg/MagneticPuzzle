using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSingleton : MonoBehaviour {

    private static AudioSingleton instance = null;

    public static AudioSingleton Instance
    {
        get { return instance; }
    }

    public static bool IsMusicEnabled = true;
    public static bool IsSoundEnabled = true;

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public static void PlayAudioSource(AudioSource aSource, Audio audioType)
    {
        if((audioType == Audio.Music) || 
           (audioType == Audio.Sound && IsSoundEnabled))
        {
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
    }
}


    