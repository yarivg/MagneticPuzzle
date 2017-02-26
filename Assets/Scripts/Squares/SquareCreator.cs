using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCreator : MonoBehaviour
{
    // The square and the circle 
    public GameObject controlableSquare;
    public GameObject drawFieldSquare;
    public GameObject MagneticCircle;

    // all the shapes in the area
    public Area[] allSquares;

    void Awake()
    {
        foreach (Area area in allSquares)
        {
            // Draw the big plane
            Vector3 squarePrefabScale = controlableSquare.transform.localScale;
            Vector3 CenterPoint = new Vector3(area.middlePosition().xAxis, 0, area.middlePosition().zAxis);

            // The add is because the distance take one square less then what is real
            Vector3 squareScale = new Vector3(squarePrefabScale.x * Mathf.Abs(area.end.xAxis - area.start.xAxis) + squarePrefabScale.x,
                                            1,
                                            squarePrefabScale.z * Mathf.Abs(area.end.zAxis - area.start.zAxis) + squarePrefabScale.z);
            GameObject father = this.gameObject.transform.Find("BigField").gameObject;
            createSquare(CenterPoint, squareScale, drawFieldSquare, father);

            if (area.isOneUnit)
            {
                createSquare(CenterPoint, squareScale, controlableSquare, this.gameObject.transform.Find("CtrlSquares").gameObject);
            }

            for (int xIndex = (int)area.start.xAxis; xIndex <= area.end.xAxis && !area.isOneUnit; xIndex++)
            {
                for (int zIndex = (int)area.start.zAxis; zIndex <= area.end.zAxis; zIndex++)
                {
                    Vector3 squarePosition = new Vector3(xIndex, 0, zIndex);
                    createSquare(squarePosition, controlableSquare.transform.localScale, controlableSquare, this.gameObject.transform.Find("CtrlSquares").gameObject);
                }

            }
        }
    }



    public static void createSquare(Vector3 squarePosition, Vector3 squareScale, GameObject squarePrefab, GameObject father)
    {
        // Init the square
        GameObject curSquare = Instantiate(squarePrefab, father.transform);
        curSquare.transform.position =  squarePosition - curSquare.transform.localPosition;
        curSquare.transform.localScale = squareScale;
        curSquare.name = "Square" + squarePosition.x + squarePosition.z;
    }
}