using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public Text bestText;

    string best;
    int lapcounter = 0;

    void OnTriggerEnter()
    {

        if (lapcounter == 1)
        {
            best = LapTimeManager.time;
        }
        if (lapcounter >= 2)
        {
            if (DateTime.Parse(LapTimeManager.time) < DateTime.Parse(best))
            {
                best = LapTimeManager.time;

            }
        }






        bestText.text = best;
        Debug.Log(best);

        lapcounter++;
        LapTimeManager.lapTime = 0;

    }
}
