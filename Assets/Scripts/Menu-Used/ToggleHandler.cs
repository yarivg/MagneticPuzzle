using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHandler : MonoBehaviour {
    
    [System.Serializable]
    public struct ChangingIcon
    {
        public GameObject gameObject;
        public string iconNameOn;
        public string iconNameOff;
        public ToggleManager manager;

        public void Load()
        {
            gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(), typeof(Sprite));
        }

        private string GetIconToLoad()
        {
            return manager.IsOn ? iconNameOn : iconNameOff;
        }
    }

    public ChangingIcon[] ToggleButtons;
    public ChangingIcon SoundButton;
    public ChangingIcon MusicButton;
    public ChangingIcon LightButton;

    void OnEnable ()
    {
        foreach (ChangingIcon toggle in ToggleButtons)
        {
            toggle.Load();
        }
    }



    #region Sound
    //private void LoadSound()
    //{
    //    SoundButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(SoundButton), typeof(Sprite));
    //}

    public void ChangeSound()
    {
        UserPreferences.Instance.ChangeSound();
        ((ManageSounds)SoundButton.manager).SetAudioActive(UserPreferences.Instance.PlaySounds);
        //SoundButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(SoundButton), typeof(Sprite));
    }
    #endregion

    #region Music
    //private void LoadMusic()
    //{
    //    MusicButton.
    //}

    public void ChangeMusic()
    {
        Debug.Log("ChangeMusic");
        UserPreferences.Instance.ChangeMusic();
        ((ManageSounds)MusicButton.manager).SetAudioActive(UserPreferences.Instance.PlayMusic);
        //MusicButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(), typeof(Sprite));
    }
    #endregion


    #region Light
    private void LoadLight()
    {
        //LightButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(LightButton), typeof(Sprite));
    }

    public void ChangeLight()
    {
        // -- TODO raz implementation later...(maybe add that in user-preferences as audio variables.

        LightButton.manager.ChangeToggle();
        //LightButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(LightButton), typeof(Sprite));
    }
    #endregion
}
