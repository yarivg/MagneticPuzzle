using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPreferences : MonoBehaviour {
    public static bool PlaySounds = true;

    private static AudioSource[] allAudioSources;
  
    void Awake()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();

        ChangeAllAudio(PlaySounds ? 1 : 0);
    }

    static void ChangeAllAudio(float volumeVal)
    {
        foreach (AudioSource audio in allAudioSources)
        {
            audio.volume = volumeVal;
        }
    }

    public static void ChangeVolume()
    {
        PlaySounds = !PlaySounds;

        AudioListener.volume = PlaySounds ? 1 : 0;
        ChangeAllAudio(AudioListener.volume);
    }
}
