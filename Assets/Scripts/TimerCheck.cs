using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCheck : MonoBehaviour
{
    public static bool timercheck = false;



    private void OnTriggerEnter(Collider other)
    {
        timercheck = true;
    }
}
