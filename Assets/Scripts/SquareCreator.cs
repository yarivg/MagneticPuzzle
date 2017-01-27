using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCreator : MonoBehaviour
{
    // The square and the circle 
    public GameObject squarePrefab;
    public GameObject circlePrefab;

    // all the shapes in the area
    public Area[] fieldValues;

    void Awake()
    {
        foreach (Area line in fieldValues)
        {
            for (int xIndex = (int)line.start.xAxis; xIndex <= line.end.xAxis; xIndex++)
            {
                for (int zIndex = (int)line.start.zAxis; zIndex <= line.end.zAxis; zIndex++)
                {
                    Vector3 squarePosition = new Vector3(xIndex, 0, zIndex);

                    // Init the square
                    GameObject curSquare = Instantiate(squarePrefab, gameObject.transform);
                    curSquare.transform.position = gameObject.transform.position + squarePosition;
                    curSquare.name = "Square" + xIndex + zIndex;

                    // Init the circle
                    GameObject circle = Instantiate(circlePrefab, curSquare.transform);
                    circle.transform.position = gameObject.transform.position + squarePosition;
                    circle.SetActive(false);
                    circle.name = "circle";
                    
                }
            }
        }
    }
}