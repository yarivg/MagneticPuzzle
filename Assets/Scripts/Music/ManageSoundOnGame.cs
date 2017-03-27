using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ManageSoundOnGame : MonoBehaviour {

    public float SoundScrollTime = 2;
    public GameObject scrollSound;
    public bool soundIsShow = false;
    Stopwatch timer = new Stopwatch();

    public void showSoundScroll()
    {
        if (!soundIsShow)
        {
            StartCoroutine(SceneLoader.FadeIn(scrollSound.transform.Find("Background").gameObject, 1, 0.02f, 0.001f));
            StartCoroutine(SceneLoader.FadeIn(scrollSound.transform.Find("Fill Area/Fill").gameObject, 1, 0.02f, 0.001f));
            StartCoroutine(SceneLoader.FadeIn(scrollSound.transform.Find("Handle Slide Area/Handle").gameObject, 1, 0.02f, 0.001f));
            soundIsShow = true;
            restartTimer();
        }

    }

    public void disableSoundScroll()
    {
        if (soundIsShow)
        {
            //  UnityEngine.Debug.Log("fade out");
            StartCoroutine(SceneLoader.FadeOut(scrollSound.transform.Find("Background").gameObject, 0.02f, 0.001f));
            StartCoroutine(SceneLoader.FadeOut(scrollSound.transform.Find("Fill Area/Fill").gameObject, 0.02f, 0.001f));
            StartCoroutine(SceneLoader.FadeOut(scrollSound.transform.Find("Handle Slide Area/Handle").gameObject, 0.02f, 0.001f));
            soundIsShow = false;
            timer.Stop();

        }
    }

    public void restartTimer()
    {
        timer.Reset();
        timer.Start();
    }

    void Update()
    {
        if(timer.ElapsedMilliseconds/1000 > SoundScrollTime)
        {
            disableSoundScroll();
        }
    }
}
