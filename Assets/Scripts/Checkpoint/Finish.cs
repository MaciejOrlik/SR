using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Check1;
    public GameObject finish;

    void OnTriggerEnter()
    {
        Check1.SetActive(true);
        finish.SetActive(false);

    }
}
