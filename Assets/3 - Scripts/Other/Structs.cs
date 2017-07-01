using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangeGameState();
public delegate void ChangeSquareState(GameObject square);
public delegate void DeviceButtonPressed();

public static class Events
{
    public static ChangeGameState START_GAME;
    public static ChangeGameState INIT_LEVEL;
    public static ChangeGameState STOP_GAME;
    public static ChangeGameState BEFORE_THE_GAME_BEGIN;
    public static ChangeSquareState CLICK_ON_EMPTY_SQUARE;
    public static ChangeSquareState CLICK_ON_MAGNETIC_SQUARE;
    public static DeviceButtonPressed BACK_BUTTON_PRESSED;
    public static ChangeSquareState COLLISION_WITH_MAGNET;

    public static void restartEvents()
    {
        START_GAME = null;
        INIT_LEVEL = null;
        STOP_GAME = null;
        BEFORE_THE_GAME_BEGIN = null;
        CLICK_ON_EMPTY_SQUARE = null;
        CLICK_ON_MAGNETIC_SQUARE = null;
        BACK_BUTTON_PRESSED = null;
        COLLISION_WITH_MAGNET = null;
    }
}


#region Enums

public enum gameStates
{
    PlaceMagnets,
    Play
}

public enum Mouseclicks
{
    leftClick,
    rightClick,

}

public enum Tags
{
    Ball,
    SourcesManager,
    Play,
    MagneticFloor,
    Floor,
    God,

    // Sounds
    Music,
    Sound,
    Electricity,
    Pickup,
    Lightning,
    Piano,
    PassLevelScreen,
    claps,
    SquareManager,
    RestartButton,
    UI
}

public enum Materials
{
    playButtonRedMat,
    Push,
    Pull,
    Empty,
    playButtonGreenMat,
    playButtonRestart,
    squareAvailable,
    blueCircle
}

public enum LightType
{
    nightLight,
    dayLight
}

public enum InGameCameraType
{
    dayCamera,
    nightCamera
}
[System.Serializable]
public enum Preferences
{
    Sound,
    Music,
    Light,
    SaveMagnets
}

public enum Audio
{
    Sound,
    Music
}

public enum GeneralInfo
{
    money,
    rewards,
    achivements,
    last_played_scene,
    difficulty
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

#endregion

#region Structs

[System.Serializable]
public struct GameVector2
{
    public float xAxis;
    public float zAxis;

    public GameVector2(float xAxis, float zAxis)
    {
        this.xAxis = xAxis;
        this.zAxis = zAxis;
    }

    public void Normalize()
    {
        double val = 1.0f / (double)Mathf.Sqrt((xAxis * xAxis) + (zAxis * zAxis));
        xAxis *= (float)val;
        zAxis *= (float)val;
    }
}

[System.Serializable]
public struct Area
{
    public GameVector2 start;
    public GameVector2 end;
    public bool isOneUnit;

    public GameVector2 middlePosition()
    {
        return new GameVector2((start.xAxis + end.xAxis) / 2, (start.zAxis + end.zAxis) / 2);
    }

    public double SquareSize()
    {
        return Mathf.Sqrt(Mathf.Pow((this.start.xAxis - this.end.xAxis), 2)
                                   + Mathf.Pow((this.start.zAxis - this.end.zAxis), 2));
    }

}

[System.Serializable]
public struct Wall
{
    public GameVector2 startPoint;
    public GameVector2 endPoint;

    public Wall(GameVector2 start, GameVector2 end)
    {
        this.startPoint = start;
        this.endPoint = end;
    }

    public GameVector2 middleWallPosition()
    {
        return new GameVector2((startPoint.xAxis + endPoint.xAxis) / 2, (startPoint.zAxis + endPoint.zAxis) / 2);
    }

    public double wallLength()
    {
        return Mathf.Sqrt(Mathf.Pow((this.startPoint.xAxis - this.endPoint.xAxis), 2)
                                   + Mathf.Pow((this.startPoint.zAxis - this.endPoint.zAxis), 2));
    }


}

public struct TransformByValue
{
    public Vector3 position;
    public Vector3 rotation;
    public float scale;

    public TransformByValue(Vector3 position, Vector3 rotation, float scale)
    {
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }
}



//[System.Serializable]
//public struct InLevelData
//{
//    public int levelValue;
//    public string levelName;
//    public bool isFirstLoad;
//    public gameStates gameState;

//    public InLevelData(int levelValue, string levelName , bool isFirstLoad , gameStates gameState)
//    {
//        this.levelValue = levelValue;
//        this.levelName = levelName;
//        this.isFirstLoad = isFirstLoad;
//        this.gameState = gameState;
//    }
/*
    public LevelData(string levelName)
    {
        this.levelName = levelName;
        this.isFirstLoad = true;
        this.gameState
    } 
    */
//}

[Serializable]
public class LevelMetadata
{
    public bool isLock;
    public bool isPass;
    public int starsPoint;

    public LevelMetadata(bool isLock, bool isPass, int starsPoint)
    {
        this.isLock = isLock;
        this.isPass = isPass;
        this.starsPoint = starsPoint;
    }
    //TODO: what??
    //public void passLevel(LevelIdentifier name)
    //{
    //    this.isPass = true;
    //    LevelMetadata nextLevel;
    //    nextLevel = UserPreferences.Instance.getLevel(new LevelIdentifier(name.diff, name.levelNumber + 1));

    //    // Is it the last level in this difficulty
    //    if(nextLevel != null)
    //    {
    //        nextLevel.isLock = false;
    //        UserPreferences.Instance.setLevel(new LevelIdentifier(name.diff, name.levelNumber + 1), nextLevel);
    //    }

    //}

}
[System.Serializable]
public class UserSeriazibleData
{

    public Dictionary<Preferences, bool> userPrefernce;
    public Dictionary<GeneralInfo, string> generalInfo;
    public Dictionary<Difficulty, Dictionary<int, LevelMetadata>> levelData;

    public UserSeriazibleData()
    {
        userPrefernce = new Dictionary<Preferences, bool>();
        generalInfo = new Dictionary<GeneralInfo, string>();
        levelData = new Dictionary<Difficulty, Dictionary<int, LevelMetadata>>();

        foreach (Preferences p in Enum.GetValues(typeof(Preferences)))
        {
            userPrefernce.Add(p, false);
        }

        foreach (GeneralInfo g in Enum.GetValues(typeof(GeneralInfo)))
        {
            generalInfo.Add(g, "");
        }

        foreach (Difficulty d in Enum.GetValues(typeof(Difficulty)))
        {
            int LevelsPerDifficulty = 8;
            Dictionary<int, LevelMetadata> temp = new Dictionary<int, LevelMetadata>();
            for (int i = 1; i <= LevelsPerDifficulty; i++)
            {
                bool isLock = false;
                if (i > 1)
                {
                    isLock = true;
                }
                temp.Add(i, new LevelMetadata(isLock, false, 0));
            }
            levelData.Add(d, temp);
        }
    }
}

public class LostByFallData
{
    public GameObject ball;
    public int frameWithSlowSpeed;
    public Vector3 prevPosition;

    public LostByFallData(GameObject ball)
    {
        this.ball = ball;
        this.frameWithSlowSpeed = 0;
        this.prevPosition = new Vector3();
    }
}

[System.Serializable]
public struct LevelIdentifier
{
    public Difficulty diff;
    public int levelNumber;

    public LevelIdentifier(Difficulty diff, int levelNumber)
    {
        this.diff = diff;
        this.levelNumber = levelNumber;
    }
}



//public struct LevelIdentifier
//{
//    public Difficulties diff;
//    public int levelNumber;
//    public string levelName;

//    public LevelIdentifier(Difficulties diff, int levelNumber)
//    {
//        this.diff = diff;
//        this.levelNumber = levelNumber;
//        levelName = diff.ToString() + "-Level" + levelNumber;
//    }
//}

#endregion