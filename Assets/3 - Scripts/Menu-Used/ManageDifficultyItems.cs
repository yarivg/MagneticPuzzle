using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageDifficultyItems : MonoBehaviour {
    public Text difficultyText;
    public GameObject[] levels;

	// Use this for initialization
	void Start () {
       // if (difficultyText == null) difficultyText = transform.FindChild("difficultyText").gameObject.GetComponent<Text>();

        if(UserPreferences.Instance.GetTempInfo("Difficulty") != null)
        {
            difficultyText.text = UserPreferences.Instance.GetTempInfo("Difficulty");

            foreach (GameObject levelButton in levels)
            {
                levelButton.transform.FindChild("Image").GetComponent<Image>().sprite = (Sprite)Resources.Load(
                                                        "Levels/" + difficultyText.text + "/" + levelButton.name, typeof(Sprite));
            }
        }
    }
}
