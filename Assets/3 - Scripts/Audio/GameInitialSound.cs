using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitialSound : MonoBehaviour {
    
    void Start()
    {
        AudioSingleton.PlayAudioSource(GameObject.FindGameObjectWithTag(Tags.Piano.ToString()).GetComponent<AudioSource>(), Audio.Music);
    }
}
