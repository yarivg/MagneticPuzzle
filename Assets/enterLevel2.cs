using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enterLevel2 : MonoBehaviour
{
    private bool isFirst = true;
    void OnCollisionEnter(Collision collision)
    {
        //if(isFirst)
        //{
        //    GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        //    foreach (GameObject ball in balls)
        //    {
        //        ball.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        //    }

        //    GameStateManager.level = "level2";
        //    GameStateManager.gameState = gameStates.PlaceMagnets;

        //    isFirst = false;
        //}
        //Debug.Log(gameStates.PlaceMagnets);
    }
}
