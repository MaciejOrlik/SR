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

    public OptionData ()
    {
        currentResolitonIndex = -1;
        qualityIndex = 1;
        isFC = true;
        vol = -40;
    }

    public OptionData (OptionData menu)
    {
        currentResolitonIndex = menu.currentResolitonIndex;
        qualityIndex = menu.qualityIndex;
        isFC = menu.isFC;
        vol = menu.vol;
    }
}
