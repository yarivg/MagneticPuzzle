using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTimer : MonoBehaviour {

    public bool turnOn;
    public float waitTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(waitFunction(waitTime));
	}
	
	IEnumerator waitFunction(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponent<Light>().enabled = turnOn;
    }

}
