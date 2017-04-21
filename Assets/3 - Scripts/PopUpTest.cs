using UnityEditor;
using UnityEngine;
using System.Collections;

// Creates an instance of a primitive depending on the option selected by the user.
public class PopUpTest : EditorWindow
{
    public string[] options = new string[] { "Cube", "Sphere", "Plane" };
    public int index = 0;
    [MenuItem("Examples/Editor GUILayout Popup usage")]
    public static void Init()
    {
        EditorWindow window = GetWindow(typeof(PopUpTest));
        window.Show();
    }

    void OnGUI()
    {
        index = EditorGUILayout.Popup(index, options);
        if (GUILayout.Button("Create"))
            InstantiatePrimitive();
    }

    void InstantiatePrimitive()
    {
        switch (index)
        {
            case 0:
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = Vector3.zero;
                break;
            case 1:
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = Vector3.zero;
                break;
            case 2:
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                plane.transform.position = Vector3.zero;
                break;
            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
    }
}