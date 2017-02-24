using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticForce : MonoBehaviour {

    public float forceFactor;
    public float maxRadius;
    public bool isPulling;
    private Vector3 MagneticOffset;

    void Start()
    {
        this.MagneticOffset = new Vector3((this.transform.lossyScale.x - 0.1f)/0.1f,
                                          0,
                                          (this.transform.lossyScale.z - 0.1f) / 0.1f);
    }
    
    void FixedUpdate () {
        GameObject[] balls = GameObject.FindGameObjectsWithTag(Tags.Ball.ToString());
        foreach (GameObject ball in balls)
        {
            Vector3 direction = (transform.position + MagneticOffset) -  ball.transform.position;
            float magnitude = direction.magnitude;

            if (magnitude < maxRadius)
            {
                direction = isPulling ? direction : -direction;
                direction.Normalize();
                ball.GetComponent<Rigidbody>().AddForce(direction * forceFactor * Time.deltaTime / magnitude);
            }
        }
    }
}
