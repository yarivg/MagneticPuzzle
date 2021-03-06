﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    protected bool enableFade;

    // Dictinary of child_scene , parent_scene to go back in hirarchi
    public static Dictionary<string, string> scenesHirarchi = 
        new Dictionary<string, string> { { "MainMenu", "MainMenu" },
                                         { "DifficultyPicker","MainMenu"},
            { "LevelsMenu","DifficultyPicker" },
            { "About","Information" },
            { "Rules","Information" },
            { "Information","MainMenu" }};



    public void PreviousScene()
    {
        if (Fading.notDuringFade)
        {
            if (scenesHirarchi.ContainsKey(SceneManager.GetActiveScene().name))
            {
                changeScene(scenesHirarchi[SceneManager.GetActiveScene().name]);
            }
            else
            {
                changeScene("LevelsMenu");
            }
        }
    }

    public virtual void changeScene(string sceneName)
    {
        Events.restartEvents();
        float waitTime = 0.5f;
        StartCoroutine(WaitForIt(waitTime, sceneName));
    }

    private IEnumerator WaitForIt(float Time, string sceneName)
    {
    
        yield return new WaitForSeconds(Time / 4);
        StartCoroutine(Fading.FadeOut(null));
        if (GameObject.FindGameObjectWithTag(Tags.PassLevelScreen.ToString()) != null && sceneName != "DifficultyPicker")
        {
            StartCoroutine(Fading.FadeIn(GameObject.FindGameObjectWithTag(Tags.PassLevelScreen.ToString()),1, 0.05f, 0.01f));
        }
        yield return new WaitForSeconds(Time * 3 / 4);
        SceneManager.LoadScene(sceneName);
        Fading.notDuringFade = true;
    }

    public void SetDifficulty(string value)
    {
        UserPreferences.Instance.AddTempValue("Difficulty", value);
    }

    public void GoToLevel(string levelName)
    {
        changeScene(levelName);
    }


    void Update()
    {
        if (GM.keys != null && GM.keys.is_back_button_pressed())
        {
            PreviousScene();
        }
    }
}
