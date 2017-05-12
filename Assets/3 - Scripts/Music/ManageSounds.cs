using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ManageSounds : MonoBehaviour
{
    private List<AudioSource> goSounds;
    private UserPreferences _uPreference;
    public SwitchButtons switchButton;
    private AudioManager audioManager;
    public Preferences pref;
    private bool bIsActive;

    void Start()
    {
        _uPreference = UserPreferences.Instance;
        audioManager = new AudioManager();

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
        audioManager.setAudio(goSounds, bIsActive);
        switchButton.setToggle(bIsActive);
        _uPreference.setPreference(pref, bIsActive);
    }
}