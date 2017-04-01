using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSliderVolume : MonoBehaviour {

    void Start()
    {
        //gameObject.GetComponent<Slider>().value = UserPreferences.Instance.getVolume();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        //UserPreferences.Instance.ChangeVolume(gameObject.GetComponent<Slider>().value);

    }
}
