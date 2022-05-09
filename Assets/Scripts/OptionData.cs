using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OptionData
{
    public int currentResolitonIndex;
    public int qualityIndex;
    public bool isFC;
    public float vol;
    public float mus;
    public bool isFPS;

    public OptionData ()
    {
        currentResolitonIndex = -1;
        qualityIndex = 1;
        isFC = true;
        vol = -40;
        mus = -40;
        isFPS = false;
    }
}
