using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float camSpeed;
    private Vector3 offset;

    public GameObject PlayCamera;

    private TransformByValue targetCamera;

    void Start()
    {
        targetCamera = new TransformByValue(gameObject.transform.position, gameObject.transform.eulerAngles, gameObject.GetComponent<Camera>().orthographicSize);
        offset = new Vector3(4, 20, -10);
        camSpeed = 0.01f;

        Events.BEFORE_THE_GAME_BEGIN += ChangeToPlayCamera;
        //Events.START_GAME += ChangeToPlayCamera;

        //  Do effect of move when we switch level
        if (GameStateManager.switchLevel == false)
        {
            //    this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        }
    }

    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + targetCamera.position, camSpeed);
        gameObject.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, targetCamera.rotation, camSpeed);
        this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(this.GetComponent<Camera>().orthographicSize, targetCamera.scale, 0.01f);
    }

    void ChangeToPlayCamera()
    {
        targetCamera = new TransformByValue(PlayCamera.transform.position, PlayCamera.transform.eulerAngles, PlayCamera.GetComponent<Camera>().orthographicSize);
    }
}
