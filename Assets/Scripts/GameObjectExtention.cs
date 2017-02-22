using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtention {

    public static void setMatirial(this GameObject gameObject,Materials material)
    {
        gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load(material.ToString(), typeof(Material));
    }

    public static bool haveTag(this GameObject gameObject,Tags targetTag)
    {
        return gameObject.tag == targetTag.ToString();
    }

    public static void setKinematic(this GameObject gameObject , bool value)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = value;
    }


}
