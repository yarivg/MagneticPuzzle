using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareHandler : MonoBehaviour {

    private static SquareHandler instance;
    private SourcesLeftManager sources;
    
    public static SquareHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SquareHandler();
            }
            return instance;
        }
    }

    public SquareHandler()
    {
        sources = GameObject.FindObjectOfType<SourcesLeftManager>();
    }



    public bool createInMagnetSquare(Vector3 position , bool enableSourcesRule , bool playSound)
    {
        if(enableSourcesRule)
        {
            if(sources.remainMagnets())
            {
                sources.DecreaseSource();
            }
            else
            {
                return false;
            }
        }
        if(playSound)
        {

        }
        GameObject parent = GameObject.FindGameObjectWithTag(Tags.SquareManager.ToString());
        SquareCreator.createSquare(position, Consts.SQUARE_SIZE, Prefabs.Instance.inMagnetSquere, parent);
        return true;

    }

    public bool createOutMagnetSquare(Vector3 position, bool enableSourcesRule, bool playSound)
    {
        if (enableSourcesRule)
        {
   //        sources.IncreaseSource();
        }

        if (playSound)
        {

        }
        GameObject parent = GameObject.FindGameObjectWithTag(Tags.SquareManager.ToString());
        SquareCreator.createSquare(position, Consts.SQUARE_SIZE, Prefabs.Instance.outMagnetSquere, parent);
        return true;
    }

    public bool createRegularSquare(Vector3 position, bool enableSourcesRule, bool playSound)
    {
        if (enableSourcesRule)
        {
            sources.IncreaseSource();
        }

        if (playSound)
        {

        }
        GameObject parent = GameObject.FindGameObjectWithTag(Tags.SquareManager.ToString());
        SquareCreator.createSquare(position, Consts.SQUARE_SIZE, Prefabs.Instance.controlSquere, parent);
        return true;
    }
}
