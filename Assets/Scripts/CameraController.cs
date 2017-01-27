using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        if(GameStateManager.switchLevel == false)
        {
            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        }

        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,player.transform.position + new Vector3(4, 20, -10),0.02f);
    }
}
