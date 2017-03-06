using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuClicks : MonoBehaviour {

    public AudioSource electricity;
    //private int toMilliseconds = 1000;

	public void ChangeScene(string sceneName)
    {
        if (electricity != null)
        {
            electricity.Play();
            StartCoroutine(WaitForIt(electricity.clip.length, sceneName));
        } else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private IEnumerator WaitForIt(float Time, string sceneName)
    {
        Debug.Log(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
        yield return new WaitForSeconds(Time);
        Debug.Log(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);

        SceneManager.LoadScene(sceneName);
    }

    public void SoundIconAction()
    {
        // TODO - change texture and remove all audios
    }
}
