using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableSquareHandler
{
    public abstract bool isSquareAvailableAndClicked(SourcesLeftMangager sources,GameObject square);
    public abstract void manageSources(SourcesLeftMangager sources);
    public abstract GameObject getMagnetPrefab();
    public void playSound(GameObject sound)
    {
        sound.playSound();
    }
}

public class ClickOnEmpty : ClickableSquareHandler
{
    public override bool isSquareAvailableAndClicked(SourcesLeftMangager sources, GameObject square)
    {
        return GameStateManager.keys.select(square) && sources.remainMagnets();
    }

    public override void manageSources(SourcesLeftMangager sources)
    {
        sources.DecreaseSource();
    }

    public override GameObject getMagnetPrefab()
    {
        return Resources.Load<GameObject>("Prefabs/Squares/InMagnetSquare");
    }
}

public class ClickOnMagnetic : ClickableSquareHandler
{
    public override bool isSquareAvailableAndClicked(SourcesLeftMangager sources, GameObject square)
    {
        return GameStateManager.keys.deselect(square);
    }

    public override void manageSources(SourcesLeftMangager sources)
    {
       
        sources.IncreaseSource();
    }

    public override GameObject getMagnetPrefab()
    {
        return Resources.Load<GameObject>("Prefabs/Squares/RegularSquare");
    }
}