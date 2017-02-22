using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBorders : MonoBehaviour {

	void Awake()
    {
        Events.STOP_GAME += addBorders;
        Events.START_GAME += removeBorders;
    }

    private void manageBorders(bool add)
    {
        foreach (Transform transform in this.transform)
        {
            if (transform.gameObject.GetComponent<MagneticForce>() == null)
            {
                transform.gameObject.GetComponent<MeshRenderer>().enabled = add;
            }
        }
    }

    private void removeBorders()
    {
        manageBorders(false);
    }

    private void addBorders()
    {
        manageBorders(true);
    } 
}
