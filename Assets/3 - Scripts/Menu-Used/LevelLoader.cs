using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : SceneLoader {

    public LevelIdentifier levelName;
    private LevelMetadata metaData;


	// Use this for initialization
	 void Start () {
        levelName = new LevelIdentifier((Difficulties)Enum.Parse(typeof(Difficulties), UserPreferences.Instance.GetTempInfo("Difficulty")),
                                        Int32.Parse(new String(name.Where(Char.IsDigit).ToArray())));
        metaData = UserPreferences.Instance.getLevel(levelName);
        setStateIcon();
	}

    public override void changeScene(string sceneName)
    {                                                                                                                                                                                                                                                                                                                                                                         
        if(!metaData.isLock)
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

    public void setStateIcon()
    {
        string whatToLoad = "Unlock";
        if(metaData.isPass)
        {
            whatToLoad = "Pass";
        }
        else if (metaData.isLock)
        {
            whatToLoad = "Lock";
        }
            transform.FindChild("stateImage").GetComponent<Image>().sprite = (Sprite)Resources.Load("Levels/StateImages/" + whatToLoad,typeof(Sprite));
    }
}


