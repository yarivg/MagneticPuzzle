using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Serializblility<T> {

    private string path;

    public Serializblility(string path)
    {
        this.path = path;
    }

    public void Save(T objToSave)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        bf.Serialize(file, objToSave);
        file.Close();
    }

    public void Load(ref T objToLoad)
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            objToLoad = (T)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.Log("The file you try to load is not exist");
        }
    }
}
