using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourcesLeftMangager : MonoBehaviour
{

    public int numOfSourcesToPaint;
    public GameObject sourcePrefab;
    private GameObject[] sources;

    void Start()
    {
        Events.BEFORE_THE_GAME_BEGIN += disableDad;
        sources = new GameObject[numOfSourcesToPaint];

        for (int i = 0; i < numOfSourcesToPaint; i++)
        {
            sources[i] = Instantiate(sourcePrefab, gameObject.transform);
            sources[i].transform.localPosition = new Vector3();
            sources[i].transform.localPosition = gameObject.transform.position + new Vector3((12 * i), 0, 0);
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
        sources[numOfSourcesToPaint++].SetActive(true);
    }

    public bool remainMagnets()
    {
        return numOfSourcesToPaint > 0;
    }

    public void disableDad()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
