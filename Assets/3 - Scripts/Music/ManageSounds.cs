using System.Linq;
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