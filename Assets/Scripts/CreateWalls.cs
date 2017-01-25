using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWalls : MonoBehaviour {

    [System.Serializable]
    public struct Wall{
        public Vector2 startPoint;
        public Vector2 endPoint;
    }

    public GameObject wallPrefab;
    private Vector2 wallOffset = new Vector2(0.5f, 0.5f);
    public Wall[] wallsArray;
    public GameObject squarePrefab;

	// Use this for initialization
	void Start () {
        GameObject wallObj;

        for (int i = 0; i < wallsArray.Length; i++)
        {
            double deg = CalculateRotation(wallsArray[i]);


            wallObj = Instantiate(wallPrefab, gameObject.transform);
            //*squarePrefab.transform.localScale.z
            wallObj.transform.position = gameObject.transform.position + new Vector3((wallsArray[i].startPoint.y + wallsArray[i].endPoint.y) / 2 - wallOffset.x,
                                                     0,
                                                     (wallsArray[i].startPoint.x + wallsArray[i].endPoint.x)  / 2 - wallOffset.y);
            wallObj.transform.rotation = Quaternion.Euler(0, (float)deg, 0);
            double wallLength = Math.Sqrt(Math.Pow((wallsArray[i].startPoint.x - wallsArray[i].endPoint.x), 2)
                                       + Math.Pow((wallsArray[i].startPoint.y - wallsArray[i].endPoint.y), 2));

            wallObj.transform.localScale = new Vector3(wallObj.transform.localScale.x, wallObj.transform.localScale.y, (float)wallLength);
            // add rotation.
        }
    }
    
    private double CalculateRotation(Wall wallObj)
    {
        Vector2 difference = new Vector2(wallObj.endPoint.x - wallObj.startPoint.x,
                                         wallObj.endPoint.y - wallObj.startPoint.y);
        difference.Normalize();

        double angleRad = Math.Atan2(difference.y, difference.x);
        var deg = angleRad * (180 / Math.PI);

        return deg;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
