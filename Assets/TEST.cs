using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(new String(name.Where(Char.IsDigit).ToArray()));

    }

    // Update is called once per frame
    void Update () {
		
	}
}
