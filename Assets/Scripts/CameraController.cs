using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float camSpeed;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(4, 20, -10);
        camSpeed = 0.02f;

        // Do effect of move when we switch level
        if (GameStateManager.switchLevel == false)
        {
            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        }
    }

    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,player.transform.position + offset, camSpeed);
    }
}
