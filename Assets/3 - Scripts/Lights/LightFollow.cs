using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour {
    public GameObject followObj;

	void Update () {
        this.transform.position = followObj.transform.position;
    }
}
