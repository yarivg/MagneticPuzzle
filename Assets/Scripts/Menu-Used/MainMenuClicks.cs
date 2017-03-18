using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuClicks : MonoBehaviour {
    
    public GameObject soundObject;
    public string soundOnName;
    public string soundOffName;
    
    void Start () {
        getGUIchildsWithDelay();
    }

    void getGUIchildsWithDelay()
    {        
        LoadSound();
    }

    private void LoadSound()
    {
        string icon_to_load = UserPreferences.Instance.PlaySounds ? soundOnName : soundOffName;
        soundObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + icon_to_load, typeof(Sprite));
    }

    public void ChangeSound()
    {
        string icon_to_load = soundObject.GetComponent<Image>().sprite.name == soundOnName ? soundOffName : soundOnName;
        soundObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + icon_to_load, typeof(Sprite));

        UserPreferences.Instance.ChangeVolume(); 
    }
}
