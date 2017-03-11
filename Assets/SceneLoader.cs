using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public AudioSource electricity;
    private AudioSource a;

    private void Start()
    {
        GameObject go = FindObjectOfType<ScreenDimensions>().gameObject;

        a = go.GetComponent<AudioSource>();
        if (a == null)
        {
            a = go.AddComponent<AudioSource>();
        }
        
        a.clip = (AudioClip)Resources.Load("Sounds/" + "electricity", typeof(AudioClip));
    }
    public void ChangeScene(string sceneName)
    {
        //a.Play();
        if (UserPreferences.PlaySounds)
        {
            if (a != null)
            {
                a.Play();
                //electricity.Play();
                StartCoroutine(WaitForIt(electricity.clip.length / 2, sceneName));
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
