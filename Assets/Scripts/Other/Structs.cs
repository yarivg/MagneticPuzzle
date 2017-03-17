using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangeGameState();
public delegate void ChangeOrientation();
public delegate void BackButtonPressed();

public static class Events
{
    public static ChangeGameState START_GAME;
    public static ChangeGameState STOP_GAME;
    public static ChangeOrientation CHANGE_ORIENTATION;
    public static BackButtonPressed BACK_BUTTON_PRESSED;

    public static void restartEvents()
    {
        STOP_GAME = null;
        START_GAME = null;
        CHANGE_ORIENTATION = null;
        BACK_BUTTON_PRESSED = null;
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
    Pickup
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

//public enum DeviceOrientation
//{
//    PORTARAIT,
//    LANDSPACE
//}

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

#endregion