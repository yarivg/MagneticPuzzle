using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserPreferences : Singleton<UserPreferences>
{


    //protected UserPreferences() { }
    //public bool PlaySounds
    //{
    //    get; private set;
    //}

    //public bool ChangeSound()
    //{
    //    PlaySounds = !PlaySounds;
    //    return PlaySounds;
    //}

    //public bool PlayMusic
    //{
    //    get; private set;
    //}

    //public bool ChangeMusic()
    //{
    //    PlayMusic = !PlayMusic;
    //    return PlayMusic;
    //}

    //public string LastScene { get; set; }
    //private float volumeVal = 1f;
    //private AudioSource[] allAudioSources;

    private UserSeriazibleData userSeriazibleData;
    private Serializblility<UserSeriazibleData> seriazible;

    private Dictionary<string, string> gameTempDict;

    void Awake()
    {
        userSeriazibleData = new UserSeriazibleData();
        seriazible = new Serializblility<UserSeriazibleData>(Application.persistentDataPath + "/savedGames.gd");
        seriazible.Save(userSeriazibleData);
       // seriazible.Load(ref userSeriazibleData);
        //LastScene = SceneManager.GetActiveScene().name;
        gameTempDict = new Dictionary<string, string>();



        //  game_dict = new Dictionary<string, string>();

        //allAudioSources = FindObjectsOfType<AudioSource>();
        //ChangeAllAudio(PlaySounds ? volumeVal : 0);
    }

    


    public void setLevel(LevelIdentifier levelName , LevelMetadata value)
    {
        userSeriazibleData.levelData[levelName.diff][levelName.levelNumber] = value;
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

    public LevelMetadata getLevel(LevelIdentifier levelName)
    {
        return userSeriazibleData.levelData[levelName.diff][levelName.levelNumber];
    }

    public bool getPreference(Preferences PreferenceName)
    {
        return userSeriazibleData.userPrefernce[PreferenceName];
    }

    public string getGeneralInfo(GeneralInfo infoName)
    {
       return userSeriazibleData.generalInfo[infoName];
    }

    public void AddTempValue(string key, string value)
    {
        this.gameTempDict[key] = value;
    }

    public string GetTempInfo(string key)
    {
        return gameTempDict.ContainsKey(key) ? this.gameTempDict[key] : null;
    }
}
