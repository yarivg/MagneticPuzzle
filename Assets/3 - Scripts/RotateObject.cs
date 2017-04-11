using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    public GameObject rotateToObj;
    public GameObject rotateObj;
    public Quaternion q2;
    void Start()
    {
        rotateToObj = GameObject.FindGameObjectWithTag(Tags.Ball.ToString());
    }
	
	// Update is called once per frame
	void Update () {

        var str = Mathf.Min(5 * Time.deltaTime, 1);
        Quaternion q = Quaternion.Lerp(rotateObj.transform.rotation,Quaternion.LookRotation(new Vector3(rotateToObj.transform.position.x,0,rotateToObj.transform.position.z) - new Vector3(rotateObj.transform.position.x, 0, rotateObj.transform.position.z)),str);
        rotateObj.transform.rotation = q;// new Quaternion(transform.rotation.x, q.y, transform.rotation.z, transform.rotation.w);
	}
}
