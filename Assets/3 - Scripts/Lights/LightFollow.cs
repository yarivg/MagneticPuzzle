using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour {
    public GameObject followObj;

	void Update () {
        this.transform.position = new Vector3(followObj.transform.position.x,
                                               transform.position.y,
                                               followObj.transform.position.z);
    }
}
