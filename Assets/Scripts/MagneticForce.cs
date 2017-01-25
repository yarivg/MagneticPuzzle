using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticForce : MonoBehaviour {

    public float forceFactor = 115;
    public float maxRadius = 4;
    public float switchRadius = 0.8f;
    private bool firstSwitch = true;
    public bool isPulling;
    private float magnitude;
    
    void FixedUpdate () {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            Vector3 direction = transform.position - ball.transform.position;
            magnitude = direction.magnitude;

            if (magnitude < maxRadius)
            {
                // Enters only once
                if (firstSwitch)
                {
                    if (magnitude < switchRadius)
                    {
                        isPulling = false;

                        // Push
                        gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("out", typeof(Material));

                        firstSwitch = false;
                    }

                }

                direction = isPulling ? direction : -direction;
                direction.Normalize();
                ball.GetComponent<Rigidbody>().AddForce(direction * forceFactor * Time.deltaTime / magnitude);
            }
        }
    }
}
