using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class PreferencesManager
{
    public abstract void setPreference(bool bIsActive);
}

public class LightPrefManager : PreferencesManager
{
    public override void setPreference(bool bIsActive)
    {
      //  LightManager _lightManager = GameObject.FindObjectOfType<LightManager>();
     //   _lightManager.changeLight(Convert.ToInt32(bIsActive));
    }
}

public class SaveMagnetStatePrefManager : PreferencesManager
{
    public override void setPreference(bool bIsActive)
    {
        Lost.saveMagnetPositions = bIsActive;
    }
}


public class AudioManager : PreferencesManager
{
    Tags tag;

    public AudioManager(Preferences pref)
    {
        if (pref == Preferences.Music)
        {
            tag = Tags.Music;
        }
        if (pref == Preferences.Sound)
        {
            tag = Tags.Sound;
        }
    }

    public override void setPreference(bool bIsActive)
    {
        List<AudioSource> goSounds = GameObject.FindGameObjectWithTag(tag.ToString()).GetComponentsInChildren<AudioSource>().ToList();
        goSounds.ForEach((sound) =>
        {
            sound.setAudio(bIsActive);
        });
    }
}
