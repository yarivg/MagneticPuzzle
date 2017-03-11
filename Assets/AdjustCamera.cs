using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCamera : MonoBehaviour {
    void Start () {
        Camera.main.aspect = 480f / 800f;
    }
}
