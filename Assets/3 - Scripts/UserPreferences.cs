using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserPreferences : Singleton<UserPreferences>
{

    private UserSeriazibleData userSeriazibleData;
    private Serializblility<UserSeriazibleData> seriazible;
    private Dictionary<string, string> gameTempDict;

    void Awake()
    {
        userSeriazibleData = new UserSeriazibleData();
        seriazible = new Serializblility<UserSeriazibleData>(Application.persistentDataPath + "/savedGames.gd");
       // seriazible.Save(userSeriazibleData);
        seriazible.Load(ref userSeriazibleData);
        gameTempDict = new Dictionary<string, string>();

        AudioSingleton.IsMusicEnabled = getPreference(Preferences.Music);
        AudioSingleton.IsSoundEnabled = getPreference(Preferences.Sound);
    }

    public void passLevel(LevelIdentifier levelIdentifier)
    {
        userSeriazibleData.levelData[levelIdentifier.diff][levelIdentifier.levelNumber].isPass = true;
        // TODO: add logic
        userSeriazibleData.levelData[levelIdentifier.diff][levelIdentifier.levelNumber + 1].isLock = false;
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

    public LevelMetadata getLevel(LevelIdentifier levelIdentifier)
    {
        if(userSeriazibleData.levelData[levelIdentifier.diff].ContainsKey(levelIdentifier.levelNumber))
        {
            return userSeriazibleData.levelData[levelIdentifier.diff][levelIdentifier.levelNumber];
        }

        return null;
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
