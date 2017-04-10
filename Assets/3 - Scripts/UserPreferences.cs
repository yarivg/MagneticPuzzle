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

    public bool ChangeSound()
    {
        PlaySounds = !PlaySounds;
        return PlaySounds;
    }

    public bool PlayMusic
    {
        get; private set;
    }

    public bool ChangeMusic()
    {
        PlayMusic = !PlayMusic;
        return PlayMusic;
    }

    public string LastScene { get; set; }
    private float volumeVal = 1f;
    private AudioSource[] allAudioSources;

    private UserSeriazibleData userSeriazibleData;
    private Serializblility<UserSeriazibleData> seriazible;

    private Dictionary<string, string> game_dict;

    void Awake()
    {
        userSeriazibleData = new UserSeriazibleData();
        seriazible = new Serializblility<UserSeriazibleData>(Application.persistentDataPath + "/savedGames.gd");
        seriazible.Load(ref userSeriazibleData);
        LastScene = SceneManager.GetActiveScene().name;
        game_dict = new Dictionary<string, string>();



        //  game_dict = new Dictionary<string, string>();

        //allAudioSources = FindObjectsOfType<AudioSource>();
        //ChangeAllAudio(PlaySounds ? volumeVal : 0);
    }

    


    public void setLevel(Levels levelName , LevelMetadata value)
    {
        userSeriazibleData.levelData[levelName] = value;
        seriazible.Save(userSeriazibleData);
    }

    public void setPreference(Preferences PreferenceName, bool value)
    {
        userSeriazibleData.userPrefernce[PreferenceName] = value;
        seriazible.Save(userSeriazibleData);

    }

    public void setGeneralInfo(GeneralInfo infoName , string value)
    {
        userSeriazibleData.generalInfo[infoName] = value;
        seriazible.Save(userSeriazibleData);
    }

    public LevelMetadata getLevel(Levels levelName)
    {
        return userSeriazibleData.levelData[levelName];
    }

    public bool getPreference(Preferences PreferenceName)
    {
        return userSeriazibleData.userPrefernce[PreferenceName];
    }

    public string getGeneralInfo(GeneralInfo infoName)
    {
       return userSeriazibleData.generalInfo[infoName];
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
