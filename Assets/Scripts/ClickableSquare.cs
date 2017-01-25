using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableSquare : MonoBehaviour
{
    [System.Serializable]
    public struct GroundNumber
    {
        int inSquare;
        int outSquare;
    }
    MagneticForce mForce;

    public GroundNumber grounds;

    void OnMouseOver()
    {

        Debug.Log(GameStateManager.gameState);
        if (GameStateManager.gameState == gameStates.PlaceMagnets)
        {
            if (Input.GetMouseButtonDown(1))
            {
                mForce = gameObject.GetComponent<MagneticForce>();
                manageSourcesLeft sourcesLeft = GameObject.FindGameObjectWithTag("sourcesManager" + GameStateManager.level.ToString()).GetComponent<manageSourcesLeft>();

                if (mForce == null)
                {
                    if (sourcesLeft.numOfSourcesToPaint > 0)
                    {
                        mForce = gameObject.AddComponent<MagneticForce>();
                        mForce.isPulling = true;

                        gameObject.transform.FindChild("circle").gameObject.SetActive(true);

                        // Pull
                        gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("in", typeof(Material));

                        sourcesLeft.DecreaseSource();
                    }
                }
                else // If MagneticForce exists
                {
                    gameObject.transform.FindChild("circle").gameObject.SetActive(false);
                    Destroy(mForce);

                    // Pull
                    gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Wood Texture 13 diffuse", typeof(Material));

                    sourcesLeft.IncreaseSource();
                }
            }        
        }
    }
}
