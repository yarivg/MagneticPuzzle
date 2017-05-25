using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ManageSounds : MonoBehaviour
{
    private List<AudioSource> goSounds;
    private UserPreferences _uPreference;
    public SwitchButtons switchButton;
    private PreferencesManager audioManager;
    public Preferences pref;
    private bool bIsActive;

    void Start()
    {
        _uPreference = UserPreferences.Instance;

        switch (pref)
        {
            case Preferences.Light:
                audioManager = new LightPrefManager();
                break;
            case Preferences.Music:
                audioManager = new AudioManager();
                break;
            case Preferences.Sound:
                audioManager = new AudioManager();
                break;
        }
        Debug.Log("manage sounds");
        // audioManager = new AudioManager();

        goSounds = transform.GetComponentsInChildren<AudioSource>().ToList();
        bIsActive = _uPreference.getPreference(pref);

        switchButton.setToggle(bIsActive);
        SetAudio();
    }

    public void ChangeAudioActive()
    {
        bIsActive = !bIsActive;
        SetAudio();
    }

    public void SetAudio()
    {
        audioManager.setPreferences( gameObject,bIsActive);
        switchButton.setToggle(bIsActive);
        _uPreference.setPreference(pref, bIsActive);
    }
}