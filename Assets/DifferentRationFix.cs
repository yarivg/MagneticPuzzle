using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifferentRationFix : MonoBehaviour {
    
    public GameObject buttonPrefab;
    public AudioSource lightningSound;
    private Rect titleRect;
    private Rect settingsRect;
    private Rect soundRect;
    private Rect playRect;
    private float dx, dy;

    void Start () {
        dx = Screen.width / 10f;
        dy = Screen.height / 10f;

        Debug.Log("Widht: " + dx + " & Height: " + dy);
        SetGUIAspectRatio();
    }

    void SetGUIAspectRatio()
    {
        if(dy > dx)
        {
            CreateIcon(5, 8, 5, "title");
            CreateIcon(3, 5, 2.5f, "soundOn");
            CreateIcon(7, 5, 2.5f, "settings");
            CreateIcon(5, 2, 4, "play");
            CreateIcon(5, 3, 5, "lightning");
        } else
        {
            CreateIcon(5, 8, 2.5f, "title");
            CreateIcon(2, 5, 1, "soundOn");
            CreateIcon(8, 5, 1, "settings");
            CreateIcon(5, 2, 2, "play");
            CreateIcon(5, 4, 2, "lightning");
        }

        lightningSound.Play();
    }

    void CreateIcon(float widthPart, float heightPart, float scaleFactor, string iconName)
    {
        GameObject go = Instantiate(buttonPrefab, transform);
        go.name = iconName;
        go.transform.position = new Vector3(widthPart * dx, heightPart * dy, go.transform.position.z);
        go.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        go.GetComponent<Image>().sprite = (Sprite)Resources.Load("MenuIcons/" + iconName, typeof(Sprite));
    }
}
