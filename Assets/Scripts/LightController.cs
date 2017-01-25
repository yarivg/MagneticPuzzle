using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    public GameObject followObj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = Vector3.Lerp(this.transform.position, followObj.transform.position, 0.1f);
        this.transform.position = new Vector3(newPosition.x, this.transform.position.y, newPosition.z);
	}
}
