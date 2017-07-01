using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fading : MonoBehaviour {

    private static float alpha_decrememnt_interval = 0.002f;
    private static float alpha_incrememnt_interval = 0.001f;
    private static float alpha_increment_value = 0.02f;
    private static float alpha_decrement_value = 0.02f;
    private static Transform[] fadeObjects;


    // Replace can_change_scene , check if we do fade-out
    public static bool notDuringFade = true;

    public static void setFadeObjects(GameObject canvas , float colorValue)
    {
        Transform[] children = canvas.GetComponentsInChildren<Transform>(true);
        List<Transform> fade_in_children = new List<Transform>(children);
        var result = fade_in_children.Where(
    (child) => (child.gameObject.GetComponent<Text>() != null && child.gameObject.GetComponent<Text>().color.a == colorValue) ||
               (child.gameObject.GetComponent<Image>() != null && child.gameObject.GetComponent<Image>().color.a == colorValue)).ToArray();
        fadeObjects = result;
    }


    public static IEnumerator FadeIn(GameObject canvas)
    {
        notDuringFade = true;
        setFadeObjects(canvas,0);
        float alpha = 0;
        while (alpha < 1)
        {
            foreach (Transform t in fadeObjects)
            {
                AssignAlpha(t.gameObject, alpha);
            }

            alpha += alpha_increment_value;
            yield return new WaitForSeconds(alpha_incrememnt_interval);
        }
    }

    public static IEnumerator FadeOut(GameObject canvas)
    {
        // ** If fading all ui **
        //GameObject canvas = FindObjectOfType<UImanager>().transform.FindChild("Canvas").gameObject;
        //Transform[] children = canvas.GetComponentsInChildren<Transform>();
        notDuringFade = false;
        if (canvas != null)
        {
            setFadeObjects(canvas,1);
            Debug.Log("fade:"+fadeObjects.Length);
        }


        float alpha = 1;
        int counter = 0;
        // Add for scenes that not load with fade in (levels) and there is not children to fade out
        if (fadeObjects != null)
        {
            while (alpha > 0)
            {
                foreach (Transform t in fadeObjects)
                {

                    if (t != null) AssignAlpha(t.gameObject, alpha);
                    counter++;
                }

                alpha -= alpha_decrement_value;
                yield return new WaitForSeconds(alpha_decrememnt_interval);
            }
        }
        notDuringFade = true;
    }

    public static IEnumerator FadeIn(GameObject gameObject, float maxAlpha, float increment, float waitTime)
    {
        notDuringFade = true;
        float alpha = gameObject.GetComponent<Image>().color.a;
        while (alpha  < maxAlpha)
        {
            AssignAlpha(gameObject, alpha);
            alpha += increment;
            yield return new WaitForSeconds(waitTime);

        }
        AssignAlpha(gameObject, maxAlpha);

    }

    public static IEnumerator FadeOut(GameObject gameObject, float decrement, float waitTime)
    {
        notDuringFade = false;
        Debug.Log(gameObject.GetComponent<Image>());
        float alpha = gameObject.GetComponent<Image>().color.a; ;
        // Add for scenes that not load with fade in (levels) and there is not children to fade out
        while (alpha > 0)
        {
            AssignAlpha(gameObject, alpha);
            alpha -= decrement;
            yield return new WaitForSeconds(waitTime);

        }
        notDuringFade = true;
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
}
