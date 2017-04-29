using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtons : MonoBehaviour {

    public Preferences pref;
    public bool isPref = true;
    public GameObject soundOn;
    public GameObject soundOff;

    void Start()
    {
        if(!UserPreferences.Instance.getPreference(pref) && isPref)
        {
           switchButtons();
        }
    }

    public void switchButtons()
    {
        soundOn.gameObject.SetActive(!soundOn.gameObject.activeSelf);
        soundOff.gameObject.SetActive(!soundOn.gameObject.activeSelf);
    }

}
