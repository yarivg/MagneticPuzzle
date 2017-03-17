using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour {
    public GameObject canvas;

    void Start () {
        if(canvas == null)
        {
            canvas = GameObject.Find("Canvas");
        }

        canvas.SetActive(true);
        StartCoroutine(SceneLoader.FadeIn(canvas));
    }
}
