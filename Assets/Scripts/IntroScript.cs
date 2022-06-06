using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public GameObject VPlayer;
    bool hasPlayed = false;
    private void Awake()
    {
        VPlayer.GetComponent<VideoPlayer>().Play();
    }
    void FixedUpdate()
    {
        if (VPlayer.GetComponent<VideoPlayer>().isPlaying)
        {
            if (!hasPlayed)
            {
                hasPlayed = true;
            }
        }    
        if (!VPlayer.GetComponent<VideoPlayer>().isPlaying)
        {
            if (hasPlayed)
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
