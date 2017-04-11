using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostManager : MonoBehaviour {

    private Lost[] losts;

    void Start()
    {
        losts = new Lost[] { new LostByFall(GameObject.FindGameObjectsWithTag(Tags.Ball.ToString())) };
        this.enabled = false;

        Events.START_GAME += enable;
    }
	
    void Update()
    {
        foreach ( Lost loose in losts)
        {
            if ( loose.isLost())
            {
                loose.executeInLost();
            }
        }
    }

    private void enable()
    {
        this.enabled = true;
    }
}
