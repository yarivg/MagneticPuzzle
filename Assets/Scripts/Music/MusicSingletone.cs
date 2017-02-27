using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingletone : MonoBehaviour {

    private static MusicSingletone instance = null;
    public static MusicSingletone Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}


    