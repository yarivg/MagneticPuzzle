using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    private static float alpha_decrememnt_interval = 0.002f;
    private static float alpha_incrememnt_interval = 0.001f;
    private static float alpha_increment_value = 0.02f;
    private static float alpha_decrement_value = 0.02f;
    private static bool can_change_screen;
    private static Transform[] fadeObjects;

    private AudioSource electricitySound
    {
        get
        {
            GameObject go = GameObject.FindObjectOfType<GameStateManager>().gameObject;
            AudioSource sound = go.GetOrAddComponent<AudioSource>();
            sound.clip = (AudioClip)Resources.Load("Sounds/" + "electricity", typeof(AudioClip));

            return sound;
        }
    }

    private void Start()
    {
        Events.BACK_BUTTON_PRESSED += PreviousScene;
        StartCoroutine(init_screen_change(0.5f));
    }

    private IEnumerator init_screen_change(float Time)
    {
        can_change_screen = false;
        yield return new WaitForSeconds(Time);
        can_change_screen = true;
    }

    private IEnumerator WaitForIt(float Time)
    {
        yield return new WaitForSeconds(Time);
    }

    private void PreviousScene()
    {
        if (can_change_screen)
        {
            Debug.Log(string.Format("Going to previous scene: {0}", UserPreferences.Instance.LastScene));
            ChangeScene(UserPreferences.Instance.LastScene);
            can_change_screen = false;
        }
    }

    public void ChangeScene(string sceneName)
    {
        if (UserPreferences.Instance.PlaySounds)
        {
            if (electricitySound != null)
            {
                electricitySound.Play();
            }
        }
        // if electricty is null this cause to exception..
        // StartCoroutine(WaitForIt(electricitySound.clip.length, sceneName));
        StartCoroutine(WaitForIt(0.5f, sceneName));
    }

    private IEnumerator WaitForIt(float Time, string sceneName)
    {
        yield return new WaitForSeconds(Time / 4);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(Time * 3 / 4);
        UserPreferences.Instance.LastScene = SceneManager.GetActiveScene().name;
        Events.BACK_BUTTON_PRESSED -= PreviousScene;
        SceneManager.LoadScene(sceneName);
    }

    public static IEnumerator FadeIn(GameObject canvas)
    {
        Transform[] children = canvas.GetComponentsInChildren<Transform>();

        // Get only children with zero alpha
        List<Transform> fade_in_children = new List<Transform>(children);
        var result = fade_in_children.Where(
            (child) => (child.gameObject.GetComponent<Text>() != null && child.gameObject.GetComponent<Text>().color.a == 0) ||
                       (child.gameObject.GetComponent<Image>() != null && child.gameObject.GetComponent<Image>().color.a == 0)).ToArray();
        fadeObjects = result;

        float alpha = 0;

        while (alpha < 1)
        {
            foreach (Transform t in result)
            {
                AssignAlpha(t.gameObject, alpha);
            }

            alpha += alpha_increment_value;
            yield return new WaitForSeconds(alpha_incrememnt_interval);
        }
    }

    public static IEnumerator FadeOut()
    {
        // ** If fading all ui **
        //GameObject canvas = FindObjectOfType<UImanager>().transform.FindChild("Canvas").gameObject;
        //Transform[] children = canvas.GetComponentsInChildren<Transform>();

        Transform[] children = fadeObjects;

        float alpha = 1;

        // Add for scenes that not load with fade in (levels) and there is not children to fade out
        if (children != null)
        {
            while (alpha > 0)
            {
                foreach (Transform t in children)
                {
                    if (t != null) AssignAlpha(t.gameObject, alpha);
                }

                alpha -= alpha_decrement_value;
                yield return new WaitForSeconds(alpha_decrememnt_interval);
            }
        }
    }

    private static void AssignAlpha(GameObject go, float alpha)
    {
        if (go.GetComponent<Image>() != null)
            go.GetComponent<Image>().color = new Color(go.GetComponent<Image>().color.r,
                                                   go.GetComponent<Image>().color.g,
                                                   go.GetComponent<Image>().color.b,
                                                   alpha);
        if (go.GetComponent<Text>() != null)
            go.GetComponent<Text>().color = new Color(go.GetComponent<Text>().color.r,
                                                   go.GetComponent<Text>().color.g,
                                                   go.GetComponent<Text>().color.b,
                                                   alpha);
    }

    public void SetDifficulty(string value)
    {
        UserPreferences.Instance.AddKeyValuePair("Difficulty", value);
    }


    public static IEnumerator FadeIn(GameObject gameObject, float maxAlpha, float increment, float waitTime)
    {

        float alpha = gameObject.GetComponent<Image>().color.a;
        while (alpha < maxAlpha)
        {
            AssignAlpha(gameObject, alpha);
            alpha += increment;
            yield return new WaitForSeconds(waitTime);
        }

    }


    public static IEnumerator FadeOut(GameObject gameObject, float decrement, float waitTime)
    {

        float alpha = gameObject.GetComponent<Image>().color.a; ;
        // Add for scenes that not load with fade in (levels) and there is not children to fade out
        while (alpha > 0)
        {
            AssignAlpha(gameObject, alpha);
            alpha -= decrement;
            yield return new WaitForSeconds(waitTime);

        }
    }

    public void stam()
    {
        Debug.Log("touch me");
    }
}
