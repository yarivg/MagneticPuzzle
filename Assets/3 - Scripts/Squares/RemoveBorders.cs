using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBorders : MonoBehaviour {

	void Awake()
    {
        Events.STOP_GAME += addBorders;
        Events.BEFORE_THE_GAME_BEGIN += removeBorders;
    }

    private void manageBorders(bool add)
    {
        foreach (Transform transform in this.transform)
        {
            if (transform.gameObject.GetComponent<MagneticForce>() == null)
            {
                transform.Find("squarePicture").GetComponent<MeshRenderer>().enabled = add; 
               // this.gameObject.GetComponent<MeshRenderer>().enabled = add;
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
