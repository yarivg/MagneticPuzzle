using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuClicks : MonoBehaviour {

    public GameObject parentGUI;
    public string soundOnName;
    public string soundOffName;
    private GameObject soundObject;
    
    void Start () {
        // **My hack because you need a little delay to get the children of the canvas
        StartCoroutine(getGUIchildsWithDelay());
    }

    IEnumerator getGUIchildsWithDelay()
    {
        yield return new WaitForSeconds(0.01f);
        soundObject = parentGUI.transform.FindChild(soundOnName).gameObject;


        LoadSound();
    }

    private void LoadSound()
    {
        string icon_to_load = UserPreferences.PlaySounds ? soundOnName : soundOffName;
        soundObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + icon_to_load, typeof(Sprite));
    }

    public void ChangeSound()
    {
        string icon_to_load = soundObject.GetComponent<Image>().sprite.name == soundOnName ? soundOffName : soundOnName;
        soundObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + icon_to_load, typeof(Sprite));

        UserPreferences.ChangeVolume(); 
    }
}
