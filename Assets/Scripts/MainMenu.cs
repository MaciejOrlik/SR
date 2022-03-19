using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject OptionsMenu;

    public void PlayGame ()
    {
        SceneManager.LoadScene("Tor_01");
    }

    public void Options ()
    {
        if (OptionsMenu.activeSelf)
        {
            OptionsMenu.SetActive(false);
        }
        else
        {
            OptionsMenu.SetActive(true);
        }
    }
    public void QuitGame ()
    {
        Application.Quit();
    }
}
