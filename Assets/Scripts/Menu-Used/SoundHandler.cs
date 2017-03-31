using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour {
    
    [System.Serializable]
    public struct ChangingIcon
    {
        public GameObject gameObject;
        public string iconNameOn;
        public string iconNameOff;
        public ManageSounds manager;
    }

    public ChangingIcon SoundButton;
    public ChangingIcon MusicButton;
    
    void Start ()
    {
        LoadSound();
        LoadMusic();
    }

    private string GetIconToLoad(ChangingIcon icon)
    {
        return icon.manager.IsOn ? icon.iconNameOn : icon.iconNameOff;
    }

    #region Sound
    private void LoadSound()
    {
        SoundButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(SoundButton), typeof(Sprite));
    }

    public void ChangeSound()
    {
        UserPreferences.Instance.ChangeSound();
        SoundButton.manager.SetAudioActive(UserPreferences.Instance.PlaySounds);
        SoundButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(SoundButton), typeof(Sprite));
    }
    #endregion

    #region Music
    private void LoadMusic()
    {
        MusicButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(MusicButton), typeof(Sprite));
    }

    public void ChangeMusic()
    {
        UserPreferences.Instance.ChangeMusic();
        MusicButton.manager.SetAudioActive(UserPreferences.Instance.PlayMusic);
        MusicButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(MusicButton), typeof(Sprite));
    }
    #endregion
}
