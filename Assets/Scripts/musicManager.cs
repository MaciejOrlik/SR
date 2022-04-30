using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class musicManager
{
    static GameObject menuMusic;
    public static void DDOL(GameObject go)
    {
        if (menuMusic == null)
        {
            UnityEngine.Object.DontDestroyOnLoad(go);
            menuMusic = go;
        }
    }

    public static void Race()
    {
        menuMusic.GetComponent<AudioSource>().Pause();
    }
    
    public static void Garage()
    {
        if (!isMenuPlaying())
        {
            menuMusic.GetComponent<AudioSource>().Play();
        }
    }

    public static bool isMenuPlaying()
    {
        if (menuMusic != null)
        {
            return menuMusic.GetComponent<AudioSource>().isPlaying;
        }
        else return false;
    }
}
