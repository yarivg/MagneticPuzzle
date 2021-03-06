﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCreator : MonoBehaviour
{
    // The square and the circle 
  //  public GameObject controlableSquare;
    public GameObject drawFieldSquare;

    // all the shapes in the area
    public Area[] allSquares;

    void Awake()
    {
        foreach (Area area in allSquares)
        {
            // Draw the big plane
            Vector3 squarePrefabScale = Prefabs.Instance.controlSquere.transform.localScale;
            Vector3 CenterPoint = new Vector3(area.middlePosition().xAxis, 0, area.middlePosition().zAxis);

            // The add is because the distance take one square less then what is real
            Vector3 squareScale = new Vector3(squarePrefabScale.x * Mathf.Abs(area.end.xAxis - area.start.xAxis) + squarePrefabScale.x,
                                            1,
                                            squarePrefabScale.z * Mathf.Abs(area.end.zAxis - area.start.zAxis) + squarePrefabScale.z);
            GameObject father = this.gameObject.transform.Find("BigField").gameObject;
            createSquare(CenterPoint, squareScale, drawFieldSquare, father);

            if (area.isOneUnit)
            {
                SquareHandler.Instance.createRegularSquare(CenterPoint,false,false);
            }

            for (int xIndex = (int)area.start.xAxis; xIndex <= area.end.xAxis && !area.isOneUnit; xIndex++)
            {
                for (int zIndex = (int)area.start.zAxis; zIndex <= area.end.zAxis; zIndex++)
                {
                    bool squareIsMagnet = false;
                    foreach(Vector3 v in Lost.MagnetsPositions)
                    {
                        if(v.x == xIndex && v.z == zIndex)
                        {
                            squareIsMagnet = true;
                        }
                    }
                    Vector3 squarePosition = new Vector3(xIndex, 0, zIndex);
                    if (squareIsMagnet)
                    {
                        SquareHandler.Instance.createInMagnetSquare(squarePosition, true, false);

                    }
                    else
                    {
                        //Vector3 squarePosition = new Vector3(xIndex * transform.localScale.x, 0, zIndex * transform.localScale.z);
                        SquareHandler.Instance.createRegularSquare(squarePosition, false, false);
                    }
                }

            }
        }
    }
    
    public static void createSquare(Vector3 squarePosition, Vector3 squareScale, GameObject squarePrefab, GameObject parent)
    {
        // Init the square
        GameObject curSquare = Instantiate(squarePrefab, parent.transform);
        curSquare.transform.position = squarePosition - curSquare.transform.localPosition;
        curSquare.transform.localPosition = squarePosition;// - curSquare.transform.localPosition;

        curSquare.transform.localScale = squareScale;
        curSquare.name = "Square" + squarePosition.x + squarePosition.z;
    }
}