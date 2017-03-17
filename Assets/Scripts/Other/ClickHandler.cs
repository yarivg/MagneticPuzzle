using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseClicker
{
    public abstract bool select(GameObject colider);
    public abstract bool deselect(GameObject colider);
    public bool touchObject(GameObject colider, Vector3 clickPosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(clickPosition);
        if (Physics.Raycast(ray,out hit))
        {
            return hit.collider.name == colider.name;
        }
        return false;
    }
    
    public bool is_back_button_pressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }
}

public class AndroidClicker : BaseClicker
{
    public override bool select(GameObject colider)
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                if (touchObject(colider, t.position) == true)
                {
                    return true;
                }
            }
        }
        return false;
    }


    public override bool deselect(GameObject colider)
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                if (touchObject(colider, t.position) == true)
                {
                    return true;
                }
            }
        }
        return false;
    }
}




public class ComputerClicker : BaseClicker
{
    public override bool select(GameObject colider)
    {
        if (Input.GetMouseButtonDown((int)Mouseclicks.leftClick))
        {
            return touchObject(colider, Input.mousePosition);
        }
        return false;
    }

    public override bool deselect(GameObject colider)
    {
        if (Input.GetMouseButtonDown((int)Mouseclicks.leftClick))
        {
            return touchObject(colider, Input.mousePosition);
        }
        return false;
    }
}
