using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clickLevelButton : MonoBehaviour {

    public int levelNumber;
    
	void Start () {
        GetComponent<Button>().onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("level" + levelNumber);
    }
}
