using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableSquare : MonoBehaviour
{
    // Magnetical power on the square
    private MagneticForce magneticalPower = null;
    private GameObject pickupGO;
    private GameObject squareCircle;
    public GameObject squarePicture;

    void Start()
    {
        pickupGO = GameObject.FindWithTag("Pickup");
        squareCircle = gameObject.transform.FindChild("squareCircle").gameObject;
        squarePicture = gameObject.transform.FindChild("squarePicture").gameObject;
        Events.START_GAME += disable;
        Events.STOP_GAME += enable;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (this.tag == Tags.MagneticFloor.ToString())
        {
            squarePicture.setMatirial(Materials.Push);
            magneticalPower.isPulling = false;
        }
    }

    void OnMouseOver()
    {
        // Just update method effect from enable
        if(this.enabled)
        {        
            SourcesLeftMangager currentSources = GameObject.Find("Level" + GameStateManager.level.ToString()).transform.Find("HUD/SourceLeftText/SourceManager").GetComponent<SourcesLeftMangager>();
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
                        squarePicture.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Pull", typeof(Material));
                        squarePicture.GetComponent<MeshRenderer>().enabled = true;

                        currentSources.DecreaseSource();

                        // Show the circle
                        squareCircle.SetActive(true);

                        PickupSound();
                    }
                }
                else if (magneticExist() && clickOnSquare(Mouseclicks.rightClick))
                {
                    this.tag = Tags.Floor.ToString();
                    Destroy(magneticalPower);
                    squarePicture.GetComponent<MeshRenderer>().material = (Material)Resources.Load(Materials.squareAvailable.ToString(), typeof(Material));
                    currentSources.IncreaseSource();
                    squareCircle.SetActive(false);
                    PickupSound();
                }
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

    void PickupSound()
    {
        if (pickupGO != null && pickupGO.GetComponent<AudioSource>() != null)
        {
            pickupGO.GetComponent<AudioSource>().Play();
        }
    }

    void enable()
    {
        this.enabled = true;
    }

    void disable()
    {
        this.enabled = false;
    }
}

