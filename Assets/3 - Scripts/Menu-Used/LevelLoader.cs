using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    public Levels levelName;
    private LevelMetadata metaData;

	// Use this for initialization
	void Start () {
       metaData = UserPreferences.Instance.getLevel(levelName);
        		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
