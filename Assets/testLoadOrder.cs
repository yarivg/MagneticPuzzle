﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLoadOrder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("objects loaded:" + GameObject.FindObjectsOfType<GameObject>().Length);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
