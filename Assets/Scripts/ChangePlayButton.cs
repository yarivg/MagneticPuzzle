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
                gameObject.setMatirial(Materials.playButtonRestart);
                
                // Remove Square Borders
                RemoveBorders();
            }
            else // Place Magnets
            {
                gameObject.setMatirial(Materials.playButtonGreenMat);

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
                transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}