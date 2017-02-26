using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void OpenMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
