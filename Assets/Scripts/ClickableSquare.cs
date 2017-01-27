using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mouseclicks
{
    leftClick,
    rightClick,
    
}

public class ClickableSquare : MonoBehaviour
{
    private MagneticForce magneticalPower = null;

    void OnCollisionEnter(Collision collision)
    {
        if(this.tag == "Magnetic Floor")
        {
            gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Out", typeof(Material));
            magneticalPower.isPulling = false;
        }
    }

    void OnMouseOver()
    {
        Debug.Log("level" + GameStateManager.level.ToString());
        Debug.Log(GameObject.Find("Level"+GameStateManager.level.ToString()));
            manageSourcesLeft currentSources = GameObject.Find("Level" + GameStateManager.level.ToString()).transform.Find("HUD/SourceLeftText/SourceManager").GetComponent<manageSourcesLeft>();
            if (!magneticExist() && clickOnSquare(Mouseclicks.leftClick))
            {
                if (currentSources.remainMagnets())
                {
                    magneticalPower = gameObject.AddComponent<MagneticForce>();
                    magneticalPower.initMagneticForce(true);
                    gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("In", typeof(Material));
                    currentSources.DecreaseSource();
                    this.tag = "Magnetic Floor";
                    gameObject.transform.FindChild("circle").gameObject.SetActive(true);


            }
        }
            else if(magneticExist() && clickOnSquare(Mouseclicks.rightClick))
            {
                Destroy(magneticalPower);
                gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Empty", typeof(Material));
                currentSources.IncreaseSource();
                this.tag = "Floor";
                gameObject.transform.FindChild("circle").gameObject.SetActive(false);

        }
    }


    bool magneticExist()
    {
        return magneticalPower != null;
    }

    bool clickOnSquare(Mouseclicks click)
    {
        return GameStateManager.gameState == gameStates.PlaceMagnets &&
            Input.GetMouseButton((int)click);
    }
}


    //void OnMouseOver()
    //{

    //    Debug.Log(GameStateManager.gameState);
    //    if (GameStateManager.gameState == gameStates.PlaceMagnets)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            mForce = gameObject.GetComponent<MagneticForce>();
    //            manageSourcesLeft sourcesLeft = GameObject.FindGameObjectWithTag("sourcesManager" + GameStateManager.level.ToString()).GetComponent<manageSourcesLeft>();

    //            if (mForce == null)
    //            {
    //                if (sourcesLeft.numOfSourcesToPaint > 0)
    //                {
    //                    mForce = gameObject.AddComponent<MagneticForce>();
    //                    mForce.isPulling = true;

    //                    gameObject.transform.FindChild("circle").gameObject.SetActive(true);

    //                    // Pull
    //                    gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("in", typeof(Material));

    //                    sourcesLeft.DecreaseSource();
    //                }
    //            }
    //            else // If MagneticForce exists
    //            {
    //                gameObject.transform.FindChild("circle").gameObject.SetActive(false);
    //                Destroy(mForce);

    //                // Pull
    //                gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Wood Texture 13 diffuse", typeof(Material));

    //                sourcesLeft.IncreaseSource();
    //            }
    //        }        
    //    }
    //}

