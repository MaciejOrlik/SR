using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint7 : MonoBehaviour
{
    public GameObject Check8;
    public GameObject Check7;

    void OnTriggerEnter()
    {
        Check8.SetActive(true);
        Check7.SetActive(false);

    }
}
