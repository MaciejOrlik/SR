using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Check1;
    public GameObject Check2;
    public LapComplete coinDisplay;
    void OnTriggerEnter()
    {
        coinDisplay.checkpointcounter++;
        Check2.SetActive(true);
        Check1.SetActive(false);

    }
}
