using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : SceneLoader {


	 void Start () {
        foreach (Transform button in gameObject.transform)
        {
            LevelMetadata metaData = UserPreferences.Instance.getLevel(new LevelIdentifier((Difficulties)Enum.Parse(typeof(Difficulties), UserPreferences.Instance.GetTempInfo("Difficulty")),
                                                                       Int32.Parse(new String(button.name.Where(Char.IsDigit).ToArray()))));
            setLevelPicture(button);
            setBacckgroundImage(button, metaData);
            setStateIcon(button, metaData);
        }
	}

    public override void changeScene(string sceneName)
    {
       LevelMetadata metaData = UserPreferences.Instance.getLevel(new LevelIdentifier
            ((Difficulties)Enum.Parse(typeof(Difficulties), UserPreferences.Instance.GetTempInfo("Difficulty")),
            Int32.Parse(new String(name.Where(Char.IsDigit).ToArray()))));


        if (!metaData.isLock)
        {
            Debug.Log("open level!");
            base.enableFade = false;

            Debug.Log("not go to new scene now because the levels not fully design");
          //  base.changeScene(sceneName);
        }
        else
        {
            Debug.Log("the level lock");
        }
    }

    private void setBacckgroundImage(Transform button, LevelMetadata metaData)
    {
        if(metaData.isLock)
        {
            button.GetComponent<Image>().sprite = (Sprite)Resources.Load("Levels/lockBackground", typeof(Sprite));
        }
    }

    private void setStateIcon(Transform button,LevelMetadata metaData)
    {
        string whatToLoad = "open-level";
        if(metaData.isPass)
        {
            whatToLoad = "pass-level";
        }
        else if (metaData.isLock)
        {
            whatToLoad = "lock-level";
        }
            button.FindChild("stateImage").GetComponent<Image>().sprite = (Sprite)Resources.Load("Levels/StateImages/" + whatToLoad,typeof(Sprite));
    }

    void setLevelPicture(Transform button)
    {
        button.FindChild("Image").GetComponent<Image>().sprite = (Sprite)Resources.Load(
                                        "Levels/" + UserPreferences.Instance.GetTempInfo("Difficulty") + "/" + button.name, typeof(Sprite));
    }
}


