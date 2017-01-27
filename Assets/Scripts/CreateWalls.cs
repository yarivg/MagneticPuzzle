using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWalls : MonoBehaviour {

    [System.Serializable]
    public struct Wall{
        public GameVector2 startPoint;
        public GameVector2 endPoint;

        public Wall(GameVector2 start,GameVector2 end)
        {
            this.startPoint = start;
            this.endPoint = end;
        }

        public GameVector2 middleWallPosition()
        {
            return new GameVector2((startPoint.xAxis + endPoint.xAxis) / 2, (startPoint.zAxis + endPoint.zAxis) / 2);
        }

        public double wallLength()
        {
            return Math.Sqrt(Math.Pow((this.startPoint.xAxis - this.endPoint.xAxis), 2)
                                       + Math.Pow((this.startPoint.zAxis - this.endPoint.zAxis), 2));
        }


    }

    public GameObject wallPrefab;
    private GameVector2 wallOffset = new GameVector2(0.5f,0.5f);
    public Wall[] wallsArray;

	// Use this for initialization
	void Start () {
        GameObject wallObj;
        foreach(Wall curWall in wallsArray)
        {
            double deg = CalculateRotation(curWall);


            wallObj = Instantiate(wallPrefab, gameObject.transform);
            wallObj.transform.position = gameObject.transform.position + 
                new Vector3(curWall.middleWallPosition().xAxis - wallOffset.xAxis,
                           0,
                           curWall.middleWallPosition().zAxis - wallOffset.zAxis);
            wallObj.transform.rotation = Quaternion.Euler(0, (float)deg, 0);


            wallObj.transform.localScale = new Vector3(wallObj.transform.localScale.x, wallObj.transform.localScale.y, (float)curWall.wallLength());
            // add rotation.
        }
    }
    
    private double CalculateRotation(Wall wallObj)
    {
        GameVector2 difference = new GameVector2(wallObj.endPoint.xAxis - wallObj.startPoint.xAxis,
                                         wallObj.endPoint.zAxis - wallObj.startPoint.zAxis);
        difference.Normalize();

        double angleRad = Math.Atan2(difference.xAxis, difference.zAxis);
        var deg = angleRad * (180 / Math.PI);
        return deg;
    }
}
