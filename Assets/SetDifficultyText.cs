using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDifficultyText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.GetComponent<Text>().text = UserPreferences.Instance.GetTempInfo("Difficulty");
	}
}
