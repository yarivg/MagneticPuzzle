using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtons : MonoBehaviour {

    public GameObject toggleOn;
    public GameObject toggleOff;
    
    public void setToggle(bool isOn)
    {
        toggleOn.gameObject.SetActive(isOn);
        toggleOff.gameObject.SetActive(!isOn);
    }

    public void changeToggle()
    {
        toggleOn.gameObject.SetActive(!toggleOn.activeSelf);
        toggleOff.gameObject.SetActive(!toggleOff.activeSelf);
    }
}
