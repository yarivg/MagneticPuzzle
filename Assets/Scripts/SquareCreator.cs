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
        // TASK LIST:
        // - make prefabs - V
        // - make control layer - X
        // - make draw layer - X

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
            createSquare(CenterPoint, squareScale, drawFieldSquare, father, false);


            if (area.isOneUnit)
            {
                createSquare(CenterPoint, squareScale, controlableSquare, this.gameObject.transform.Find("CtrlSquares").gameObject, true);
            }


            for (int xIndex = (int)area.start.xAxis; xIndex <= area.end.xAxis && !area.isOneUnit; xIndex++)
            {
                for (int zIndex = (int)area.start.zAxis; zIndex <= area.end.zAxis; zIndex++)
                {
                    Vector3 squarePosition = new Vector3(xIndex, 0, zIndex);
                    createSquare(squarePosition, controlableSquare.transform.localScale, controlableSquare, this.gameObject.transform.Find("CtrlSquares").gameObject, true);
                }

            }
        }
    }



    void createSquare(Vector3 squarePosition, Vector3 squareScale, GameObject squarePrefab, GameObject father, bool makeCircleBehind)
    {
        // Init the square
        GameObject curSquare = Instantiate(squarePrefab, father.transform);
        curSquare.transform.position =  squarePosition - curSquare.transform.localPosition;



        curSquare.transform.localScale = squareScale;
        curSquare.name = "Square" + squarePosition.x + squarePosition.z;

        //// Init the circle
        //if (makeCircleBehind)
        //{
        //    createMagneticCircle(curSquare);
        //}
    }

    //// Controlable - by square
    //void createMagneticCircle(GameObject squareInside)
    //{
    //    GameObject circle = Instantiate(MagneticCircle, squareInside.transform);
    //    circle.name = "circle";
    //    circle.transform.position = new Vector3( squareInside.transform.position.x,
    //                                             squareInside.transform.position.y + 0.1f,
    //                                             squareInside.transform.position.z);
    //}
}