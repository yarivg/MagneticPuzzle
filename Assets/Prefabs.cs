using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs {

    private static Prefabs instance = null;
    public  GameObject inMagnetSquere;
    public  GameObject outMagnetSquere;
    public  GameObject controlSquere;

    public static Prefabs Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Prefabs();
            }
            return instance;
        }
    }

    public Prefabs()
    {
        inMagnetSquere = Resources.Load<GameObject>("Prefabs/Squares/InMagnetSquare");
        outMagnetSquere = Resources.Load<GameObject>("Prefabs/Squares/OutMagneticSquare");
        controlSquere = Resources.Load<GameObject>("Prefabs/Squares/RegularSquare");
    }

}
