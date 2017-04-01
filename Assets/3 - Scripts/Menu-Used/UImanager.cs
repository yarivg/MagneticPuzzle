using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {
    public GameObject canvas;

    void Start () {
        if(canvas == null)
        {
            canvas = GameObject.Find("Canvas");
        }

        StartCoroutine(SceneLoader.FadeIn(canvas));
    }
}
