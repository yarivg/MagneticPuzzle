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

        StartCoroutine(Fading.FadeIn(canvas));

        if(GameObject.FindGameObjectWithTag(Tags.PassLevelScreen.ToString()) != null)
        {
            StartCoroutine(Fading.FadeOut(GameObject.FindGameObjectWithTag(Tags.PassLevelScreen.ToString()), 0.01f, 0.005f));
        }
        
    }
}
