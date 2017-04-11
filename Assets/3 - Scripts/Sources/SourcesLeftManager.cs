using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SourcesLeftManager : MonoBehaviour
{
    public int nOpened;
    public Text strOpened;

    void Start()
    {
        SetTexts();
    }

    private void SetTexts()
    {
        strOpened.text = nOpened.ToString();
    }

    public void DecreaseSource()
    {
        nOpened -= nOpened > 0 ? 1 : 0;
        SetTexts();
    }

    public void IncreaseSource()
    {
        nOpened += 1;
        SetTexts();
    }

    public bool remainMagnets()
    {
        return nOpened > 0;
    }

}
