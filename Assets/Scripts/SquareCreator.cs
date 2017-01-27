using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GameVector2
{
    public float xAxis;
    public float zAxis;

    public GameVector2(float xAxis, float zAxis)
    {
        this.xAxis = xAxis;
        this.zAxis = zAxis;
    }

    public void Normalize()
    {
        double val = 1.0f / (double)Mathf.Sqrt((xAxis* xAxis) + (zAxis * zAxis));
        xAxis *= (float)val;
        zAxis *= (float)val;
    }
}


// to define non merooba field
[System.Serializable]
public struct Area
{
    public GameVector2 start;
    public GameVector2 end;
}

public class SquareCreator : MonoBehaviour
{

    // The square and the circle that radiuses 
    public GameObject squarePrefab;
    public GameObject circlePrefab;

    // the 
    public Area[] fieldValues;
    // public int widthNumber;
    // public int lengthNumber;
    // GameObject[,] squares;

    //List<List<>>

    void Awake()
    {
        //      squares = new GameObject[lengthNumber, widthNumber];

        foreach (Area line in fieldValues)
        {
            for (int xIndex = (int)line.start.xAxis; xIndex <= line.end.xAxis; xIndex++)
            {
                for (int zIndex = (int)line.start.zAxis; zIndex <= line.end.zAxis; zIndex++)
                {
                    GameObject curSquare = Instantiate(squarePrefab, gameObject.transform);
                    curSquare.transform.position = gameObject.transform.position  + new Vector3(xIndex, 0, zIndex);
                    GameObject circle = Instantiate(circlePrefab, curSquare.transform);
                    circle.transform.position = gameObject.transform.position + new Vector3(xIndex, 0, zIndex);
                    circle.SetActive(false);
                    circle.name = "circle";
                    curSquare.name = "Square" + xIndex + zIndex;

                }
            }

        }

        //for(int i = 0; i< lengthNumber; i++)
        //{
        //    for (int j = 0; j < widthNumber; j++)
        //    {
        //        squares[i, j] = Instantiate(squarePrefab, gameObject.transform);
        //        GameObject circle = Instantiate(circlePrefab, squares[i, j].transform);
        //        circle.SetActive(false);
        //        circle.name = "circle";
        //        squares[i, j].transform.position = gameObject.transform.position + new Vector3(i, 0, j);
        //        squares[i, j].name = "Square" + i + j;
        //    }
        //}
    }
}

//    public void CleanMap()
//    {
//        manageSourcesLeft sourcesLeft = GameObject.FindGameObjectWithTag("sourcesManager" + GameStateManager.level.ToString()).GetComponent<manageSourcesLeft>();

//        for (int i = 0; i < lengthNumber; i++)
//        {
//            for (int j = 0; j < widthNumber; j++)
//            {
//                if (squares[i, j].GetComponent<MagneticForce>() != null)
//                {
//                    Destroy(squares[i, j].GetComponent<MagneticForce>());

//                    squares[i, j].transform.FindChild("circle").gameObject.SetActive(false);

//                    // Pull
//                    squares[i, j].GetComponent<MeshRenderer>().material = (Material)Resources.Load("Wood Texture 13 diffuse", typeof(Material));

//                    sourcesLeft.IncreaseSource();
//                }
//            }
//        }
//    }
//}
