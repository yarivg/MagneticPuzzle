using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserPreferences : Singleton<UserPreferences>
{

    protected UserPreferences() { }
    public bool PlaySounds
    {
        get; private set;
    }

    public void ChangeSound()
    {
        PlaySounds = !PlaySounds;
    }

    public bool PlayMusic
    {
        get; private set;
    }

    public void ChangeMusic()
    {
        PlayMusic = !PlayMusic;
    }

    public string LastScene { get; set; }
    private float volumeVal = 1f;
    private AudioSource[] allAudioSources;
    private Dictionary<string, string> game_dict;

    void Awake()
    {
        PlaySounds = true;
        PlayMusic = true;
        LastScene = SceneManager.GetActiveScene().name;
        game_dict = new Dictionary<string, string>();
        
        //allAudioSources = FindObjectsOfType<AudioSource>();
        //ChangeAllAudio(PlaySounds ? volumeVal : 0);
    }

    //void ChangeAllAudio(float volumeVal)
    //{
    //    allAudioSources = FindObjectsOfType<AudioSource>();

    //    foreach (AudioSource audio in allAudioSources)
    //    {
    //        if (audio != null)
    //        {
    //            audio.volume = volumeVal;
    //        }
    //    }
    //}

    //public float getVolume()
    //{
    //    return volumeVal;
    //}

    //public void ChangeVolume()
    //{
    //    PlaySounds = !PlaySounds;

    //    //AudioListener.volume = PlaySounds ? volumeVal : 0;
    //    //ChangeAllAudio(AudioListener.volume);
    //}
    
    //public void ChangeVolume(float volume)
    //{
    //    PlaySounds = !PlaySounds;

    //    //AudioListener.volume = volume;
    //    //ChangeAllAudio(AudioListener.volume);
    //}

    public void AddKeyValuePair(string key, string value)
    {
        this.game_dict[key] = value;
    }

    public string GetValue(string key)
    {
        return game_dict.ContainsKey(key) ? this.game_dict[key] : null;
    }
}
