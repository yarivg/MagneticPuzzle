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
                GetComponent<MeshRenderer>().material =
                    (Material) Resources.Load(Materials.playButtonRestart.ToString(), typeof(Material));
            }
            else
            {
                GetComponent<MeshRenderer>().material =
                    (Material)Resources.Load(Materials.playButtonGreenMat.ToString(), typeof(Material));

                GameStateManager.gameState = gameStates.PlaceMagnets;
                GameStateManager.switchLevel = false;
                GameStateManager.loadScene();
            }
        }
    }
}