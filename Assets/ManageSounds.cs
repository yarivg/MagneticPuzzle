using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSounds : ToggleManager {

    // The name of the object is the prefernce
    Preferences pref;
    private List<AudioSource> mySounds;

    private new void OnEnable()
    {
        InitManager();
    }

    private void OnDisable()
    {
        mySounds.Clear();
    }

    private void InitManager()
    {
        pref = (Preferences)Enum.Parse(typeof(Preferences), name);
        base.OnEnable();
        mySounds = new List<AudioSource>(transform.GetComponentsInChildren<AudioSource>());
        SetAudioActive(UserPreferences.Instance.getPreference(pref));
        Debug.Log("sounds:"+ mySounds.Count);
        //mySounds = new List<AudioSource>();

        //foreach (Transform childTransfrorm in transform)
        //{
        //    if (childTransfrorm.gameObject.GetComponent<AudioSource>() != null)
        //    {
        //        mySounds.Add(childTransfrorm.gameObject.GetComponent<AudioSource>());
        //    }
        //}
    }

    public void SetAudioActive(bool bIsActive)
    {
        Debug.Log(gameObject.name);
        Debug.Log(bIsActive);
        IsOn = bIsActive;

        mySounds.ForEach((sound) => {
            Debug.Log("child name " + sound.name);
            if(bIsActive)
            {
                sound.UnPause();
                sound.volume = 1;

            }
            else
            {
                sound.Pause();
                sound.volume = 0;
            }
            try
            {
                UserPreferences.Instance.setPreference((pref), bIsActive);
            }
            catch { Debug.Log("cant write"); }

        });
    }
}
