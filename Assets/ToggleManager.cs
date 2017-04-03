using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    public bool IsOn { get; set; }

    protected void OnEnable()
    {
        IsOn = true;
    }

    public void ChangeToggle()
    {
        IsOn = !IsOn;
    }
}
