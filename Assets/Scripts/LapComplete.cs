using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LapComplete : MonoBehaviour
{
	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;

	public GameObject scorecanvas;

	public AudioMixer sound;
	private OptionData data;
	private bool end = false;

	public string time = "00:00.0";
	public string min;
	public string sec;
	public string mili;

	public ScoreShow ss;

	public int coin;
	public int allcoins;


    private void Awake()
    {
		data = OptionSave.OpLoad();
    }

   

    void OnTriggerEnter()
	{
		if (LapTimeManager.MinuteCount <= 9)
		{
			min = "0" + LapTimeManager.MinuteCount.ToString() + ":";
			MinuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ":";
		}
		else
		{
			min = "" + LapTimeManager.MinuteCount.ToString() + ":";
			MinuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ":";
		}

		if (LapTimeManager.SecondCount <= 9)
		{
			sec = "0" + LapTimeManager.SecondCount.ToString() + ".";
			SecondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
		}
		else
		{
			sec = "" + LapTimeManager.SecondCount.ToString() + ".";
			SecondDisplay.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
		}

		mili = "" + LapTimeManager.MilliCount.ToString("f0");
		MilliDisplay.GetComponent<Text>().text = "" + LapTimeManager.MilliCount;

		time = min + sec + mili;

		Debug.Log(time);
		LapTimeManager.MinuteCount = 0;
		LapTimeManager.SecondCount = 0;
		LapTimeManager.MilliCount = 0;

		allcoins = coin;
		


		if (TimerCheck.timercheck == true)
		{
			scorecanvas.SetActive(true);
			Time.timeScale = 0f;
			musicManager.RaceFinish();
			sound.SetFloat("Sound", -80);
			sound.SetFloat("Volume", 6);
			TimerCheck.timercheck = false;


			

		}

	}
	public void LoadMenu()
	{
		ss.zapiszTabliceWynikow();
		scorecanvas.SetActive(false);
		Time.timeScale = 1f;
		float set = (((data.vol + 80) / 80) * 9) + 1;
		sound.SetFloat("Sound", (Mathf.Log10(set) - 1) * 80);
		sound.SetFloat("Volume", 0);
		SceneManager.LoadScene("Garage");
	}
	public void QuitGame()
	{
		ss.zapiszTabliceWynikow();
		Application.Quit();
	}

	public string sendTime()
    {
		return time;
    }

	public int sendCoin()
    {
		return allcoins;
    }
}
