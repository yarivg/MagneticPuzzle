using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLevelsItems : MonoBehaviour {

    [System.Serializable]
    public struct Difficulty
    {
        public string difficultyName;
        public Color backgroundColor;
        public int levelsNumber;
    }

    public Vector2 startPieceOfScreen;
    public Vector2 buttonScale;
    public GameObject levelButtonPrefab;
    public GameObject difficultyTextPrefab;
    public int levelsInRow;
    public Vector2 differenceBetweenItems;

    public Difficulty difficulty;
    
    private Vector2 constant_offset;

    void Start () {
        GameObject goDifficulty;

        constant_offset = new Vector2(startPieceOfScreen.x * ScreenDimensions.widthUnit,
                             startPieceOfScreen.y * ScreenDimensions.heightUnit);

        goDifficulty = Instantiate(difficultyTextPrefab, transform);
        goDifficulty.GetComponent<Text>().text = difficulty.difficultyName;
        goDifficulty.name = difficulty.difficultyName;
        //goDifficulty.GetComponent<Text>().color = buttonColor;
        goDifficulty.transform.localScale = new Vector3(1, 1, 1);
        goDifficulty.transform.localPosition = new Vector3(0, 2f * ScreenDimensions.heightUnit, 0);
            //new Vector3(5 * ScreenDimensions.widthUnit, Screen.height - 1.6f * ScreenDimensions.heightUnit, 0);

        int nLevelIndex = 0;
        Vector2 levelOffset = Vector2.zero;

        while(nLevelIndex < difficulty.levelsNumber)
        {
            levelOffset.x = (nLevelIndex % levelsInRow) * differenceBetweenItems.x * ScreenDimensions.widthUnit;
            levelOffset.y = (nLevelIndex / levelsInRow) * differenceBetweenItems.y * ScreenDimensions.heightUnit;
            CreateLevelButton(nLevelIndex, difficulty.difficultyName, constant_offset + levelOffset);
            nLevelIndex++;
        }

        //for(int nLevelIndex = 0; nLevelIndex < difficulty.levelsNumber; nLevelIndex++)
        //{
        //    CreateLevelButton(nLevelIndex, difficulty.difficultyName, offset);

        //    if(nLevelIndex % 2 == 0)
        //    {
        //        offset.y += differenceBetweenItems.y * ScreenDimensions.heightUnit;
        //    } else
        //    {
        //        offset.y = startPieceOfScreen.y * ScreenDimensions.heightUnit;
        //        offset.x += differenceBetweenItems.x * ScreenDimensions.widthUnit;
        //    }
        //}
    }
    
    private void CreateLevelButton(int levelIndex, string difficultyName, Vector2 offset)
    {
        int levelNumber = levelIndex + 1;

        GameObject goLevel = Instantiate(levelButtonPrefab, transform);

        goLevel.name = "Button" + levelIndex;
        goLevel.transform.Find("Image")
               .GetComponent<Image>().sprite = (Sprite)Resources.Load(
                                                            "Levels/" + difficultyName + "/level" + levelNumber, typeof(Sprite));
        // Only displaying first level -                    "Levels/Begginer/level1", typeof(Sprite));

        goLevel.transform.Find("Text").GetComponent<Text>().text = levelNumber.ToString();

        goLevel.transform.localScale = new Vector3(buttonScale.x, buttonScale.y, 1);
        goLevel.transform.position = new Vector3(offset.x,
                                                 Screen.height - offset.y,
                                                 0);

        // Created a script which listen to clicks with the level number
        clickLevelButton clButton = goLevel.AddComponent<clickLevelButton>();
        clButton.levelNumber = levelNumber;
    }
}