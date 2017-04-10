using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtons : MonoBehaviour {

    public Preferences pref;
    public bool isPref = true;

    void Start()
    {
        if(!UserPreferences.Instance.getPreference(pref) && isPref)
        {
            switchButtons();
        }
    }

    public void switchButtons()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(!child.gameObject.activeSelf);
        }
    }

}
