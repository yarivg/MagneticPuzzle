﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserPreferences : Singleton<UserPreferences>
{

    protected UserPreferences() { }
    public bool PlaySounds = true;
    public string LastScene { get; set; }
    private float volumeVal = 0.05f;
    private AudioSource[] allAudioSources;
    private Dictionary<string, string> game_dict;

    void Awake()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
        ChangeAllAudio(PlaySounds ? volumeVal : 0);
        
        LastScene = SceneManager.GetActiveScene().name;
        game_dict = new Dictionary<string, string>();
        game_dict.Add("Yariv", "Gavriel");
    }

    void ChangeAllAudio(float volumeVal)
    {
        allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audio in allAudioSources)
        {
            if (audio != null)
            {
                audio.volume = volumeVal;
            }
        }
    }

    public void ChangeVolume()
    {
        PlaySounds = !PlaySounds;

        AudioListener.volume = PlaySounds ? volumeVal : 0;
        ChangeAllAudio(AudioListener.volume);
    }

    public void AddKeyValuePair(string key, string value)
    {
        this.game_dict[key] = value;
    }

    public string GetValue(string key)
    {
        return game_dict.ContainsKey(key) ? this.game_dict[key] : null;
    }
}