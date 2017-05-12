using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour {

    public Text levelName;
    private GM gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag(Tags.God.ToString()).GetComponent<GM>();

        levelName.text = "Easy | Level " + gameManager.levelIdentifier.levelNumber;
    }
}
