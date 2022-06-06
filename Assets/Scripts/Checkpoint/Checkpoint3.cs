using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint3 : MonoBehaviour
{
    public GameObject Check3;
    public GameObject Check4;
    public LapComplete coinDisplay;
    void OnTriggerEnter()
    {
        coinDisplay.checkpointcounter++;
        Check4.SetActive(true);
        Check3.SetActive(false);

    }
}
