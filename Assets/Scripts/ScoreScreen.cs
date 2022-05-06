using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ScoreScreen : MonoBehaviour
{
    public GameObject Score;
	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;
	public AudioMixer sound;
	private OptionData data;

    private void Start()
    {
		data = OptionSave.OpLoad();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            Score.SetActive(true);
            Time.timeScale = 0f;

			sound.SetFloat("Sound", -80);
			sound.SetFloat("Volume", 6);

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
		float set = (((data.vol + 80) / 80) * 9) + 1;
        sound.SetFloat("Sound", (Mathf.Log10(set) - 1) * 80);
        sound.SetFloat("Volume", 0);
		SceneManager.LoadScene("Garage");

	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
