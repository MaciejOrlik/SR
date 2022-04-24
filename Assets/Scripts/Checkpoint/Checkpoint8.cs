using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint8 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Check8;
    public GameObject Finish;

    void OnTriggerEnter()
    {
        Finish.SetActive(true);
        Check8.SetActive(false);

    }
}
