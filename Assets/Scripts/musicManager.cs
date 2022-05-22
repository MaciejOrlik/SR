using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class musicManager
{
    static GameObject menuMusic;
    static GameObject gameMusicIntro;
    static GameObject gameMusicMid;
    static GameObject gameMusicOutro;
    static AudioClip r_intro;
    static AudioClip r_mid;
    static AudioClip r_outro;
    static bool isRaceActive;
    public static void DDOL(GameObject go)
    {
        if (menuMusic == null)
        {
            UnityEngine.Object.DontDestroyOnLoad(go);
            menuMusic = go;
        }
    }

    public static void DDOLTWO(GameObject intr, GameObject md, GameObject outr)
    {
        if (gameMusicIntro == null)
        {
            UnityEngine.Object.DontDestroyOnLoad(intr);
            gameMusicIntro = intr;
        }
        if (gameMusicMid == null)
        {
            UnityEngine.Object.DontDestroyOnLoad(md);
            gameMusicMid = md;
        }
        if (gameMusicOutro == null)
        {
            UnityEngine.Object.DontDestroyOnLoad(outr);
            gameMusicOutro = outr;
        }
    }

    public static void Race()
    {
        menuMusic.GetComponent<AudioSource>().Pause();
        audioReset();
        gameMusicIntro.GetComponent<AudioSource>().Play();
        isRaceActive = true;
    }
    
    public static void RaceUptade()
    {
        Debug.Log(gameMusicIntro.GetComponent<AudioSource>().isPlaying.ToString() + isRaceActive.ToString() + gameMusicMid.GetComponent<AudioSource>().isPlaying.ToString());
        if (!gameMusicIntro.GetComponent<AudioSource>().isPlaying)
        {
            if (isRaceActive)
            {
                if (!gameMusicMid.GetComponent<AudioSource>().isPlaying)
                {
                    gameMusicMid.GetComponent<AudioSource>().Play();
                }
            }
        }
    }

    public static void RaceFinish()
    {
        audioReset();
        gameMusicOutro.GetComponent<AudioSource>().Play();
        isRaceActive = false;
    }

    static void audioReset()
    {
        if (gameMusicIntro.GetComponent<AudioSource>().isPlaying) { gameMusicIntro.GetComponent<AudioSource>().Stop(); }
        if (gameMusicMid.GetComponent<AudioSource>().isPlaying) { gameMusicMid.GetComponent<AudioSource>().Stop(); }
        if (gameMusicOutro.GetComponent<AudioSource>().isPlaying) { gameMusicOutro.GetComponent<AudioSource>().Stop(); }
    }

    public static void Garage()
    {
        audioReset();
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
