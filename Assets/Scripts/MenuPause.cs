using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuPause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer sound;
    private OptionData data;
    public GameObject scorecanvas;
    private void Start()
    {
        musicManager.Race();
        data = OptionSave.OpLoad();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        musicManager.RaceUptade();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        float set = (((data.vol + 80) / 80) * 9) + 1;
        sound.SetFloat("Sound", (Mathf.Log10(set) - 1) * 80);
        sound.SetFloat("Volume", 0);
        musicManager.resumeRace();
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        sound.SetFloat("Sound",-80);
        sound.SetFloat("Volume",-80);
        musicManager.pauseRace();
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("Garage");
    }
    public void QuitGame()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
