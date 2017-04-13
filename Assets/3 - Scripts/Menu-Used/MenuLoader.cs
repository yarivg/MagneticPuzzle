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

    void Update()
    {
        if (GM.keys != null && GM.keys.is_back_button_pressed())
        {
            PreviousScene();
        }
    }
}
