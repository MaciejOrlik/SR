using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
    public GameObject Score;
	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;
	void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            Score.SetActive(true);
            Time.timeScale = 0f;

			if (LapTimeManager.SecondCount <= 9)
			{
				SecondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
			}
			else
			{
				SecondDisplay.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
			}

			if (LapTimeManager.MinuteCount <= 9)
			{
				MinuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ".";
			}
			else
			{
				MinuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ".";
			}

			MilliDisplay.GetComponent<Text>().text = "" + LapTimeManager.MilliCount;

			LapTimeManager.MinuteCount = 0;
			LapTimeManager.SecondCount = 0;
			LapTimeManager.MilliCount = 0;



		}
        
    }
	public void LoadMenu()

	{
		Time.timeScale = 1f;
		
		SceneManager.LoadScene("Garage");

	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
