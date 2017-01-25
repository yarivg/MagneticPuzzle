using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCreator : MonoBehaviour {

    public GameObject squarePrefab;
    public GameObject circlePrefab;
    public int widthNumber;
    public int lengthNumber;
    GameObject[,] squares;

    void Awake()
    {
        squares = new GameObject[lengthNumber, widthNumber];

        for(int i = 0; i< lengthNumber; i++)
        {
            for (int j = 0; j < widthNumber; j++)
            {
                squares[i, j] = Instantiate(squarePrefab, gameObject.transform);
                GameObject circle = Instantiate(circlePrefab, squares[i, j].transform);
                circle.SetActive(false);
                circle.name = "circle";
                squares[i, j].transform.position = gameObject.transform.position + new Vector3(i, 0, j);
                squares[i, j].name = "Square" + i + j;
            }
        }
    }

    public void CleanMap()
    {
        manageSourcesLeft sourcesLeft = GameObject.FindGameObjectWithTag("sourcesManager" + GameStateManager.level.ToString()).GetComponent<manageSourcesLeft>();

        for (int i = 0; i < lengthNumber; i++)
        {
            for (int j = 0; j < widthNumber; j++)
            {
                if (squares[i, j].GetComponent<MagneticForce>() != null)
                {
                    Destroy(squares[i, j].GetComponent<MagneticForce>());

                    squares[i, j].transform.FindChild("circle").gameObject.SetActive(false);

                    // Pull
                    squares[i, j].GetComponent<MeshRenderer>().material = (Material)Resources.Load("Wood Texture 13 diffuse", typeof(Material));

                    sourcesLeft.IncreaseSource();
                }
            }
        }
    }
}
