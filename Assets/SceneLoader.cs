using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public AudioSource electricity;

	public void ChangeScene(string sceneName)
    {
        if(UserPreferences.PlaySounds)
        {
            if (electricity != null)
            {
                electricity.Play();
                StartCoroutine(WaitForIt(electricity.clip.length, sceneName));

                return;
            }
        }

        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator WaitForIt(float Time, string sceneName)
    {
        yield return new WaitForSeconds(Time);
     
        SceneManager.LoadScene(sceneName);
    }
}
