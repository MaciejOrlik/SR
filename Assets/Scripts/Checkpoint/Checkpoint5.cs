using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint5 : MonoBehaviour
{
    public GameObject Check6;
    public GameObject Check5;
    public LapComplete coinDisplay;
    void OnTriggerEnter()
    {
        coinDisplay.checkpointcounter++;
        Check6.SetActive(true);
        Check5.SetActive(false);

    }
}
