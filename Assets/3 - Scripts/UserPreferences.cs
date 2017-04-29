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
        seriazible.Load(ref userSeriazibleData);
        gameTempDict = new Dictionary<string, string>();
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
        if(userSeriazibleData.levelData[levelName.diff].ContainsKey(levelName.levelNumber))
        {
            return userSeriazibleData.levelData[levelName.diff][levelName.levelNumber];
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
