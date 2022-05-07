using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    public Text timerText;
    public static float lapTime;

    public static string time = "00:00";



    // Update is called once per frame
    void Update()
    {

        lapTime += Time.deltaTime;

        string minutes = Mathf.Floor(lapTime / 60).ToString();
        string seconds = Mathf.RoundToInt(lapTime % 60).ToString("f0");
        
        time = minutes + ":" + seconds;
        timerText.text = time;
        
    }
}
