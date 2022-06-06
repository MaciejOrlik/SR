using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public GameObject VPlayer;
    int i=0;

    private void Awake()
    {
        VPlayer.GetComponent<VideoPlayer>().Play();
    }
    void FixedUpdate()
    {
        if (!VPlayer.GetComponent<VideoPlayer>().isPlaying)
        {
            i++;

            if (i>25)
            {
                SceneManager.LoadScene("Menu");
            }
            
        }    
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
