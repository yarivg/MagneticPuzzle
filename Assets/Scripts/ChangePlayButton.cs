using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayButton : MonoBehaviour
{

    private GameObject squareManager;

    private void Start()
    {
        squareManager = GameObject.FindWithTag("SquareManager");
    }

    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown((int)Mouseclicks.leftClick))
        {
            // Start Game
            if (GameStateManager.gameState == gameStates.PlaceMagnets)
            {
                GameStateManager.gameState = gameStates.Play;
                GetComponent<MeshRenderer>().material =
                    (Material) Resources.Load(Materials.playButtonRestart.ToString(), typeof(Material));
                
                // Remove Square Borders
                RemoveBorders();
            }
            else // Place Magnets
            {
                GetComponent<MeshRenderer>().material =
                    (Material)Resources.Load(Materials.playButtonGreenMat.ToString(), typeof(Material));

                GameStateManager.gameState = gameStates.PlaceMagnets;
                GameStateManager.switchLevel = false;
                GameStateManager.loadScene();
            }
        }
    }

    private void RemoveBorders()
    {
        foreach(Transform transform in squareManager.transform)
        {
            if (transform.gameObject.GetComponent<MagneticForce>() == null)
            {
                transform.gameObject.GetComponent<ClickableSquare>().squarePicture.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}