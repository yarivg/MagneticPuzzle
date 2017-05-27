using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : SceneLoader
{
     void Start()
    {
        base.enableFade = true;
    }

    public override void changeScene(string sceneName)
    {
        base.changeScene(sceneName);
    }

}



