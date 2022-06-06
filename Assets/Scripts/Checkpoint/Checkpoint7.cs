using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint7 : MonoBehaviour
{
    public GameObject Check8;
    public GameObject Check7;
    public LapComplete coinDisplay;
    void OnTriggerEnter()
    {
        coinDisplay.checkpointcounter++;
        Check8.SetActive(true);
        Check7.SetActive(false);

    }
}
