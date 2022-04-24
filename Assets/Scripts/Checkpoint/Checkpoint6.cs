using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint6 : MonoBehaviour
{
    public GameObject Check7;
    public GameObject Check6;

    void OnTriggerEnter()
    {
        Check7.SetActive(true);
        Check6.SetActive(false);

    }
}
