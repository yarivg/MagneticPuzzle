using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtention {

    public static void setMaterial(this GameObject gameObject,Materials material)
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

    public static void playSound(this GameObject gameObject)
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// Gets or add a component. Usage example:
    /// BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>();
    /// </summary>
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        T result = gameObject.GetComponent<T>();
        if (result == null)
        {
            result = gameObject.AddComponent<T>();
        }

        return result;
    }


    public static void setAudio(this AudioSource audioSource, bool activity)
    {
        if (activity)
        {
            audioSource.UnPause();
            audioSource.volume = 1;
        }
        else
        {
            audioSource.Pause();
            audioSource.volume = 0;
        }
    }

}
