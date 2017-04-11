﻿using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ManageSounds : MonoBehaviour
{
    private List<AudioSource> goSounds;
    public Preferences pref;
    private bool bIsActive;

    void Start()
    {
       goSounds = transform.GetComponentsInChildren<AudioSource>().ToList();
       bIsActive = UserPreferences.Instance.getPreference(pref);
       SetAudio(bIsActive);

    }

    //private void OnEnable()
    //{
    //    InitManager();
    //}

    //private void OnDisable()
    //{
    //    goSounds.Clear();
    //}

    //private void InitManager()
    //{
    //    goSounds = new List<AudioSource>(GetComponents<AudioSource>());
    //    Debug.Log(goSounds.Count);

    //    // Setting audio sources active/inactive
    //    bIsActive = UserPreferences.Instance.getPreference(pref);
    //    SetAudio(bIsActive);
    //    //mySounds = new List<AudioSource>();

    //    //foreach (Transform childTransfrorm in transform)
    //    //{
    //    //    if (childTransfrorm.gameObject.GetComponent<AudioSource>() != null)
    //    //    {
    //    //        mySounds.Add(childTransfrorm.gameObject.GetComponent<AudioSource>());
    //    //    }
    //    //}
    //}

    public void ChangeAudioActive()
    {
        bIsActive = !bIsActive;
        SetAudio(bIsActive);
    }

    private void SetAudio(bool isSoundActive)
    {
        goSounds.ForEach((sound) => {
            if (isSoundActive)
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
        Debug.Log("audio " + isSoundActive);
        UserPreferences.Instance.setPreference(pref, isSoundActive);
    }
}