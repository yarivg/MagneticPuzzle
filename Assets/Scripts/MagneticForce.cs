using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticForce : MonoBehaviour {

    public float forceFactor;
    public float maxRadius;
    public bool isPulling;
    private float magnitude;
    public bool useDefaultValues = true;

    void Start()
    {
        if(useDefaultValues)
        {
            defaultMagneticValues();
        }
    }
    
    void FixedUpdate () {
        GameObject[] balls = GameObject.FindGameObjectsWithTag(Tags.Ball.ToString());
        foreach (GameObject ball in balls)
        {
            Vector3 direction = transform.position - ball.transform.position;
            magnitude = direction.magnitude;

            if (magnitude < maxRadius)
            {
                direction = isPulling ? direction : -direction;
                direction.Normalize();
                ball.GetComponent<Rigidbody>().AddForce(direction * forceFactor * Time.deltaTime / magnitude);
            }
        }
    }

    public void initMagneticForce(bool isPulling)
    {
        this.isPulling = isPulling;
    }

    private void defaultMagneticValues()
    {
        forceFactor = 115;
        maxRadius = 4;
    }

}
