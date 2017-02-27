using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMenuItems : MonoBehaviour {

    [System.Serializable]
    public struct Difficulty
    {
        public string difficultyName;
        public Color backgroundColor;
        public int levelsNumber;
    }

    public GameObject levelButtonPrefab;
    public GameObject difficultyTextPrefab;
    public int levelsInRow;
    public int differenceBetweenItems;

    // Help buttons
    public Button nextButton;
    public Button prevButton;

    public Difficulty[] difficulties;
    
    private Vector2 offset;

    void Start () {
        Camera.main.aspect = 480f / 800f;
        Debug.Log(UnityEngine.Screen.height);
        Debug.Log(UnityEngine.Screen.width);

        GameObject goDifficulty;
        Color buttonColor;
        offset = new Vector2(0, 0);

        // Create difficulty
        for (int difficultyIndex = 0; difficultyIndex < difficulties.Length; difficultyIndex++)
        {
            // Weird representation of color in unity that's why this assign needed
            buttonColor = difficulties[difficultyIndex].backgroundColor;
            buttonColor = new Color(buttonColor.r, buttonColor.g, buttonColor.b);

            goDifficulty = Instantiate(difficultyTextPrefab, transform);
            goDifficulty.GetComponent<Text>().text = difficulties[difficultyIndex].difficultyName;
            goDifficulty.name = difficulties[difficultyIndex].difficultyName;
            goDifficulty.GetComponent<Text>().color = buttonColor;
            goDifficulty.transform.localScale = new Vector3(1, 1, 1);
            goDifficulty.transform.position = new Vector3(710 + offset.x, 75,0);

            int odd = difficulties[difficultyIndex].levelsNumber % levelsInRow > 0 ? 1 : 0;
            int numOfRows = difficulties[difficultyIndex].levelsNumber / levelsInRow + odd;
            // Create level buttons
            for (int levelIndex = 0; levelIndex < numOfRows; levelIndex++)
            {
                for(int inRow = 0; inRow < levelsInRow && levelIndex * levelsInRow + inRow < difficulties[difficultyIndex].levelsNumber; inRow++)
                {
                    CreateLevelButton(goDifficulty, levelIndex * levelsInRow + inRow + 1, difficulties[difficultyIndex].difficultyName, buttonColor, offset);
                    offset.x += differenceBetweenItems;
                }

                offset.y -= differenceBetweenItems;
                offset.x = 0;
            }

            offset.x += difficulties[difficultyIndex].levelsNumber % 2 == 0 ? 50 : 100;
            offset.y = differenceBetweenItems;
        }
        
        nextButton.onClick.AddListener(NextLevelPage);
        prevButton.onClick.AddListener(PrevLevelPage);
    }

    // TODO : use UnityEngine.screen.height/width for fixing image streching
    private void CreateLevelButton(GameObject difficultyParent, int levelIndex, string difficultyName, Color buttonColor, Vector2 offset)
    {
        int levelNumber = levelIndex + 1;

        GameObject goLevel = Instantiate(levelButtonPrefab, difficultyParent.transform);

        goLevel.name = "Button" + levelIndex;
        goLevel.GetComponent<Image>().color = buttonColor;
        goLevel.transform.FindChild("Image")
               .GetComponent<Image>().sprite = (Sprite)Resources.Load(
                                                            "Levels/" + difficultyName + "/level" + levelNumber, typeof(Sprite));

        goLevel.transform.localScale = new Vector3(1, 1, 1);
        goLevel.transform.position = new Vector3(200 + goLevel.transform.position.x + offset.x,
                                                 120 + offset.y,
                                                 0);

        // Created a script which listen to clicks with the level number
        clickLevelButton clButton = goLevel.AddComponent<clickLevelButton>();
        clButton.levelNumber = levelNumber;
    }

    void NextLevelPage()
    {
        if (transform.position.x >= -offset.x)
        {
            Debug.Log(offset.x / difficulties.Length);
            transform.position = new Vector3(transform.position.x - offset.x / difficulties.Length, transform.position.y, transform.position.z);
        }
    }

    void PrevLevelPage()
    {
        if(transform.position.x <= 0)
        {
            transform.position = new Vector3(transform.position.x + offset.x / difficulties.Length, transform.position.y, transform.position.z);
        }
    }
}