using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    //public GameObject endLevel1;
    //public GameObject cameraLevel1;

    //public GameObject endLevel2;
    //public GameObject cameraLevel2;

    private float speed;
    private float minSpeed = 0.35f;
    private int framesWithSlowSpeed;
    private Vector3 prevPosition;

    // Use this for initialization
    void Start()
    {
        framesWithSlowSpeed = 0;
        prevPosition = transform.position;
   //     cameraLevel2.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (GameStateManager.gameState == gameStates.Play)
        {
            DetectIfLost();
         //   DetectIfWon();
            GetComponent<Rigidbody>().isKinematic = false;
        }
        else if (GameStateManager.gameState == gameStates.PlaceMagnets)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }

    }

    private void DetectIfLost()
    {
        speed = (transform.position - prevPosition).magnitude / Time.deltaTime;
        prevPosition = transform.position;

        if (speed < minSpeed) framesWithSlowSpeed= framesWithSlowSpeed + 1;
        else framesWithSlowSpeed = 0;


        if ((transform.position.y < -5 || framesWithSlowSpeed > 90))
        {
            Debug.Log("load");
            GameStateManager.switchLevel = false;
            SceneManager.LoadScene("level" + GameStateManager.level.ToString());
            GameStateManager.gameState = gameStates.PlaceMagnets;
        }

            //SquareCreator
            //    = GameObject.FindGameObjectWithTag("squares" + GameStateManager.level.ToString()).GetComponent<SquareCreator>();
            //squares.CleanMap();

            //GameObject playButton = GameObject.FindGameObjectWithTag("playButton" + GameStateManager.level.ToString()).gameObject;
            //playButton.GetComponent<MeshRenderer>().material = (Material)Resources.Load("playButtonGreenMat", typeof(Material));

            //if (GameStateManager.level == "level1")
            //{
            //    transform.position = GameStateManager.ballPositions[0];
            //}
            //else if (GameStateManager.level == "level2")
            //{
            //    transform.position = GameStateManager.ballPositions[1];
            //}

            ////manageSourcesLeft sourcesLeft = GameObject.FindGameObjectWithTag("sourcesManager" + GameStateManager.level.ToString()).GetComponent<manageSourcesLeft>();

            ////for (int i = sourcesLeft.numOfSourcesToPaint; i < sourcesLeft.sources.Length; i++)
            ////{
            ////    sourcesLeft.IncreaseSource();
            ////}

            //GameStateManager.gameState = gameStates.PlaceMagnets;
        }

        //if (Input.GetKeyDown("space"))
        //{
        //    SquareCreator squares = GameObject.FindGameObjectWithTag("squares" + GameStateManager.level.ToString()).GetComponent<SquareCreator>();
        //    squares.CleanMap();
        //    this.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        //    this.transform.position = GameStateManager.ballPositions[1];
        //    manageSourcesLeft sourcesLeft = GameObject.FindGameObjectWithTag("sourcesManager" + GameStateManager.level.ToString()).GetComponent<manageSourcesLeft>();

        //    for (int i = sourcesLeft.numOfSourcesToPaint; i < sourcesLeft.sources.Length; i++)
        //    {
        //        sourcesLeft.IncreaseSource();
        //    }

        //    GameStateManager.gameState = gameStates.PlaceMagnets;
        //}
    }


//    private void DetectIfWon()
//    {
//        float minDist = 1.5f;
//        if (GameStateManager.level == "level1")
//        {
//            if ((transform.position - endLevel1.transform.position).magnitude < minDist)
//            {
//                cameraLevel1.SetActive(false);
//                cameraLevel2.SetActive(true);
//            }
//        }
//        else if (GameStateManager.level == "level2")
//        {
//            if ((transform.position - endLevel2.transform.position).magnitude < minDist)
//            {
//                //cameraLevel1.SetActive(true);
//                //cameraLevel2.SetActive(false);
//            }
//        }
//    }
//}
