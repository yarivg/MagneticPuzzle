using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : SceneLoader
{
    public override void Start()
    {
      //  Events.BACK_BUTTON_PRESSED += base.PreviousScene;
       // StartCoroutine(init_screen_change(0.5f));
        base.Start();
        base.enableFade = true;
    }

    public override void changeScene(string sceneName)
    {
        base.changeScene(sceneName);

    }
}
