using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePlayButton : MonoBehaviour {

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown((int)Mouseclicks.leftClick))
        {
            if (GameStateManager.gameState == gameStates.PlaceMagnets) {
                GameStateManager.gameState = gameStates.Play;
                gameObject.setMatirial(Materials.playButtonRedMat);
            }
        }
    }
}