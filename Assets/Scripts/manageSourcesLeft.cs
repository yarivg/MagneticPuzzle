using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSourcesLeft : MonoBehaviour {

    public int numOfSourcesToPaint;
    public GameObject sourcePrefab;
    private GameObject[] sources;

	void Start () {
        sources = new GameObject[numOfSourcesToPaint];

        for (int i = 0; i < numOfSourcesToPaint;i++)
        {
            sources[i] = Instantiate(sourcePrefab, gameObject.transform);
            sources[i].transform.position = gameObject.transform.position + new Vector3(1.2f+ (1.5f * i), 0, -2.5f);
            sources[i].name = "source" + i;
        }
	}
	
    public void DecreaseSource()
    {
        if (numOfSourcesToPaint > 0)
        {
            sources[--numOfSourcesToPaint].SetActive(false);
        }
    }

    public void IncreaseSource()
    {
        Debug.Log(gameObject.name);
        Debug.Log(sources.Length);
        Debug.Log(numOfSourcesToPaint);
        sources[numOfSourcesToPaint++].SetActive(true);
    }

    public bool remainMagnets()
    {
        return numOfSourcesToPaint > 0;
    }
}
