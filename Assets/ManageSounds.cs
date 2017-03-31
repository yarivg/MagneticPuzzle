using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSounds : MonoBehaviour {

    private List<AudioSource> mySounds;
    public bool IsOn { get; set; }

	// Use this for initialization
	void Start () {
        IsOn = true;
        mySounds = new List<AudioSource>();

        foreach(Transform childTransfrorm in transform)
        {
            if(childTransfrorm.gameObject.GetComponent<AudioSource>() != null)
            {
                mySounds.Add(childTransfrorm.gameObject.GetComponent<AudioSource>());
            }
        }
	}
	
    public void SetAudioActive(bool bIsActive)
    {
        IsOn = bIsActive;
        mySounds.ForEach((sound) => {
            if(bIsActive)
            {
                sound.UnPause();
                sound.volume = 1;
            } else
            {
                sound.Pause();
                sound.volume = 0;
            }
            
        });
    }
}
