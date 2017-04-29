using System;
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
            changeScene(SceneLoader.scenesHirarchi[SceneManager.GetActiveScene().name]);
        }
    }

    public virtual void changeScene(string sceneName)
    {
        float waitTime = enableFade == true ? 0.5f : 0;
        StartCoroutine(WaitForIt(waitTime, sceneName));
    }

    private IEnumerator WaitForIt(float Time, string sceneName)
    {
        yield return new WaitForSeconds(Time / 4);
        StartCoroutine(Fading.FadeOut());
        yield return new WaitForSeconds(Time * 3 / 4);
        SceneManager.LoadScene(sceneName);
    }

    public void SetDifficulty(string value)
    {
        UserPreferences.Instance.AddTempValue("Difficulty", value);
    }

    private string GetDifficulty()
    {
        return UserPreferences.Instance.GetTempInfo("Difficulty");
    }
    public void GoToLevel(string levelVal)
    {
        if (GetDifficulty() != null)
        {
            changeScene(GetDifficulty() + "-Level" + levelVal);
        }
    }


    void Update()
    {
        if (GM.keys != null && GM.keys.is_back_button_pressed())
        {
            PreviousScene();
        }
    }
}
