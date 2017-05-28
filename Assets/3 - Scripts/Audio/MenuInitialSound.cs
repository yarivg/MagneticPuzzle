using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInitialSound : MonoBehaviour {

    void Start () {
        AudioSingleton.PlayAudioSource(GameObject.FindGameObjectWithTag(Tags.Lightning.ToString()).GetComponent<AudioSource>(), Audio.Sound);
    }
}
