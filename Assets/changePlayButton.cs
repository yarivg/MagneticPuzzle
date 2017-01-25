using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePlayButton : MonoBehaviour {

    // Update is called once per frame
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameStateManager.gameState == gameStates.PlaceMagnets) {
                GameStateManager.gameState = gameStates.Play;
                GetComponent<MeshRenderer>().material = (Material)Resources.Load("playButtonRedMat", typeof(Material));
            }
        }
    }
}