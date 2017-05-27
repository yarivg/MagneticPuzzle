using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ManagePreference : MonoBehaviour
{
    public SwitchButtons switchButton;
    public Preferences pref;
    private UserPreferences _uPreference;
    private PreferencesManager preferenceManager;
    private bool bIsActive;

    void Start()
    {
        validation();
        _uPreference = UserPreferences.Instance;

        switch (pref)
        {
            case Preferences.Light:
                preferenceManager = new LightPrefManager();
                break;
            case Preferences.Music:
                preferenceManager = new AudioManager(pref);
                break;
            case Preferences.Sound:
                preferenceManager = new AudioManager(pref);
                break;
        }
        bIsActive = _uPreference.getPreference(pref);
        switchButton.setToggle(bIsActive);
        setPreference();
    }

    public void ChangePreferenceActive()
    {
        bIsActive = !bIsActive;
        setPreference();
    }

    public void setPreference()
    {
        preferenceManager.setPreference(bIsActive);
        switchButton.setToggle(bIsActive);
        _uPreference.setPreference(pref, bIsActive);
    }

    public void validation()
    {
        if (switchButton == null)
        {
            throw new System.Exception("The object switch button is null!");
        }
    }

}