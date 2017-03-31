using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourcesLeftMangager : MonoBehaviour
{

    public int numOfOpenSources;
    public int numOfLockedSources;
    public GameObject lockedSourcePrefab;
    public GameObject openedSourcePrefab;
    public GameObject sourcePanel;
    private GameObject[] sources;
    private DrawMagnetsIconData drawMagnetData;
    private int numOfSourcesToPaint;

    void Start()
    {
        //// Disable source object when game begin
        sources = new GameObject[numOfOpenSources + numOfLockedSources];
        //drawMagnetData = new DrawMagnetsIconData(new Vector2(-30, -45), new Vector2(55, -75), 4);
        //numOfSourcesToPaint = numOfLockedSources + numOfOpenSources;

        //int sourceIndex;

        //// Create open magnet sources
        //for (sourceIndex = 0; sourceIndex < numOfOpenSources; sourceIndex++)
        //{
        //    CreateSourceMagnet(openedSourcePrefab, sourceIndex);
        //}

        //// Create locked magnet sources
        //for (sourceIndex = numOfOpenSources; sourceIndex < numOfOpenSources + numOfOpenSources; sourceIndex++)
        //{
        //    CreateSourceMagnet(lockedSourcePrefab, sourceIndex);
        //}

        //GameObject panel = Instantiate(sourcePanel, gameObject.transform);

        //panel.transform.localPosition = new Vector3((sources[0].transform.localPosition.x + Mathf.Max(sources[numOfSourcesToPaint - 1].transform.localPosition.x, sources[drawMagnetData.numOfMagnetsInRow - 1].transform.localPosition.x)) / 2 + 10,
        //                                            (sources[0].transform.localPosition.y + sources[numOfSourcesToPaint - 1].transform.localPosition.y) / 2 - 15,
        //                                            0);
        //panel.transform.localScale = new Vector3( sourcePanel.transform.localScale.x * drawMagnetData.numOfMagnetsInRow,
        //                                          sourcePanel.transform.localScale.y * Mathf.Ceil((float)numOfSourcesToPaint / drawMagnetData.numOfMagnetsInRow),
        //                                          0);
    }

    private void CreateSourceMagnet(GameObject sourcePrefab, int nSourceIndex)
    {
        sources[nSourceIndex] = Instantiate(sourcePrefab, gameObject.transform);
        sources[nSourceIndex].transform.localScale = sourcePrefab.transform.localScale;
        sources[nSourceIndex].transform.localPosition = new Vector3(drawMagnetData.magnetStartPosition.x + (drawMagnetData.magnetStartPosition.x + drawMagnetData.diffrenceBetweenMagnetsm.x * (nSourceIndex % drawMagnetData.numOfMagnetsInRow)),
          drawMagnetData.magnetStartPosition.y + (drawMagnetData.magnetStartPosition.y + drawMagnetData.diffrenceBetweenMagnetsm.y * (nSourceIndex / drawMagnetData.numOfMagnetsInRow)),
                                                          0);
        sources[nSourceIndex].name = "Magnet" + nSourceIndex;
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

    private Vector2 findCenterMagnet(int numOfMagnets, int rowLength)
    {
        int y = numOfMagnets / rowLength / 2;
        int x = Mathf.Min(numOfMagnets/2 , rowLength / 2); 

        return new Vector2(x,y);
    }
}
