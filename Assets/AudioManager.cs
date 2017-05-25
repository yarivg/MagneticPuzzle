using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class PreferencesManager
{
    public abstract void setPreferences(GameObject g, bool bIsActive);
}

public class LightPrefManager : PreferencesManager
{
    public override void setPreferences(GameObject g, bool bIsActive)
    {
        LightManager _lightManager = GameObject.FindObjectOfType<LightManager>();
        _lightManager.changeLight(Convert.ToInt32(bIsActive));
    }
}


public class AudioManager : PreferencesManager
{

    public override void setPreferences(GameObject g, bool bIsActive)
    {
        List<AudioSource> goSounds = g.transform.GetComponentsInChildren<AudioSource>().ToList();
        goSounds.ForEach((sound) =>
        {
            if (bIsActive)
            {
                sound.UnPause();
                sound.volume = 1;
            }
            else
            {
                sound.Pause();
                sound.volume = 0;
            }

        });
    }
}


//public class AudioManager
//{

//    public void setAudio(List<AudioSource> goSounds, bool bIsActive)
//    {
//        goSounds.ForEach((sound) =>
//        {
//            if (bIsActive)
//            {
//                sound.UnPause();
//                sound.volume = 1;
//            }
//            else
//            {
//                sound.Pause();
//                sound.volume = 0;
//            }

//        });
//    }
//}