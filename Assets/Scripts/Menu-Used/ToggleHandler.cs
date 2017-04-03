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
        bool isActive = UserPreferences.Instance.ChangeSound();
        ((ManageSounds)SoundButton.manager).SetAudioActive(isActive);
        SoundButton.Load();
        //SoundButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(SoundButton), typeof(Sprite));
    }
    #endregion

    #region Music
    public void ChangeMusic()
    {
        Debug.Log("ChangeMusic");
        bool isActive = UserPreferences.Instance.ChangeMusic();
        ((ManageSounds)MusicButton.manager).SetAudioActive(isActive);
        MusicButton.Load();
        //MusicButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(), typeof(Sprite));
    }
    #endregion


    #region Light
    public void ChangeLight()
    {
        // -- TODO raz implementation later...(maybe add that in user-preferences as audio variables.

        LightButton.manager.ChangeToggle();
        LightButton.Load();
        //LightButton.gameObject.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + GetIconToLoad(LightButton), typeof(Sprite));
    }
    #endregion
}
