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
            if(line.isOneUnit)
            {
                Vector3 squarePrefabScale = squarePrefab.transform.localScale;
                Vector3 CenterPoint = new Vector3(line.middlePosition().xAxis,0,line.middlePosition().zAxis);

                // The add is because the distance take one square less then what is real
                Vector3 squareScale = new Vector3(squarePrefabScale.x * Mathf.Abs(line.end.xAxis - line.start.xAxis) + squarePrefabScale.x,
                                                1,
                                                squarePrefabScale.z * Mathf.Abs(line.end.zAxis - line.start.zAxis) + squarePrefabScale.z);
                initSquare(CenterPoint, squareScale);
                
            }


            for (int xIndex = (int)line.start.xAxis; xIndex <= line.end.xAxis && !line.isOneUnit; xIndex++)
            {
                for (int zIndex = (int)line.start.zAxis; zIndex <= line.end.zAxis; zIndex++)
                {
                    Vector3 squarePosition = new Vector3(xIndex, 0, zIndex);
                    initSquare(squarePosition, squarePrefab.transform.localScale);
                    
                }
            }
        }

    }

    void initSquare(Vector3 squarePosition,Vector3 squareScale)
    {
        // Init the square
        GameObject curSquare = Instantiate(squarePrefab, gameObject.transform);
        curSquare.transform.position = gameObject.transform.position + squarePosition;
        curSquare.transform.localScale = squareScale;
        curSquare.name = "Square" + squarePosition.x + squarePosition.z;

        // Init the circle
        GameObject circle = Instantiate(circlePrefab, curSquare.transform);
        circle.transform.position = gameObject.transform.position + squarePosition;
        circle.SetActive(false);
        circle.name = "circle";
    }
}