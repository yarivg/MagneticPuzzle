﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableSquare : MonoBehaviour
{
    // Magnetical power on the square
    private MagneticForce magneticalPower = null;

    void OnCollisionEnter(Collision collision)
    {
        if(this.tag == Tags.MagneticFloor.ToString())
        {
            gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load(Materials.Push.ToString(), typeof(Material));
            magneticalPower.isPulling = false;
        }
    }

    void OnMouseOver()
    {
            ManageSourcesLeft currentSources = GameObject.Find("Level" + GameStateManager.level.ToString()).transform.Find("HUD/SourceLeftText/SourceManager").GetComponent<ManageSourcesLeft>();
            if (!magneticExist() && clickOnSquare(Mouseclicks.leftClick))
            {
                if (currentSources.remainMagnets())
                {
                    this.tag = Tags.MagneticFloor.ToString();

                    // Put pull magnet
                    magneticalPower = gameObject.AddComponent<MagneticForce>();
                    magneticalPower.initMagneticForce(true);
                    magneticalPower.initMagneticOffset(new Vector3(this.transform.localScale.x * 5, 0, this.transform.localScale.z * 5));

                    // Set picture
                    gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Pull", typeof(Material));
                    gameObject.GetComponent<MeshRenderer>().enabled = true;

                currentSources.DecreaseSource();

                    // Show the circle
                    gameObject.transform.FindChild("circle").gameObject.SetActive(true);
            }
        }
            else if(magneticExist() && clickOnSquare(Mouseclicks.rightClick))
            {
                this.tag = Tags.Floor.ToString();
                Destroy(magneticalPower);
                gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load(Materials.Empty.ToString(), typeof(Material));
                currentSources.IncreaseSource();
                gameObject.transform.FindChild("circle").gameObject.SetActive(false);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
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

