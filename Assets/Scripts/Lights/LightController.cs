using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    private float lightSpeed;
    public GameObject followObj;
	
    void Start()
    {
        lightSpeed = 0.1f;
    }

	void Update () {
        Vector3 newPosition = Vector3.Lerp(this.transform.position, followObj.transform.position, lightSpeed);
        this.transform.position = new Vector3(newPosition.x, this.transform.position.y, newPosition.z);
	}
}
