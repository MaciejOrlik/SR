using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chechpoint4 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Check4;
    public GameObject Check5;
    public LapComplete coinDisplay;
    void OnTriggerEnter()
    {
        coinDisplay.checkpointcounter++;
        Check5.SetActive(true);
        Check4.SetActive(false);

    }
}
