using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawObj : MonoBehaviour {

    public GameObject drawObj;
	// Use this for initialization
	void Start () {
        Instantiate(drawObj, this.transform);
	}
}
