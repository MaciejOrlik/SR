using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Check2;
    public GameObject Check3;

    public LapComplete coinDisplay;

    void OnTriggerEnter()
    {
        coinDisplay.checkpointcounter++;
        Check3.SetActive(true);
        Check2.SetActive(false);

    }
}
