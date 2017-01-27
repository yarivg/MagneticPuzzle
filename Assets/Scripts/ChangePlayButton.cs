using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayButton : MonoBehaviour {

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown((int)Mouseclicks.leftClick))
        {
            if (GameStateManager.gameState == gameStates.PlaceMagnets)
            {
                GameStateManager.gameState = gameStates.Play;
                GetComponent<MeshRenderer>().material = (Material)Resources.Load(Matirials.playButtonRedMat.ToString(), typeof(Material));
            }
        }
    }
}