using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableScript : MonoBehaviour
{
    public float waitTime = 1;
    
    void Start()
    {
        StartCoroutine(disableObject(waitTime));
    }
    
    private IEnumerator disableObject(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
        Debug.Log("Disabled" + gameObject.name);
    }
}