using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MapSelect : MonoBehaviour
{
    public TextMeshProUGUI mapName;
    private string[] mapNames = { "1 - Countryside", "2 - ", "3 - ", "4 - " };
    private int mapIndex = 0;

    private void Start()
    {
        DispMap();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Garage");
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Tor_0" + (mapIndex+1).ToString());
    }
    public void Back ()
    {
        SceneManager.LoadScene("Garage");
    }

    private void DispMap()
    {
        mapName.text = mapNames[mapIndex];
    }

    public void IncMap()    //mapIndex ++
    {
        if (mapIndex < 3)
        {
            mapIndex++;
        }
        else
        {
            mapIndex = 0;
        }
        DispMap();
    }

    public void DecMap()    //mapIndex --
    {
        if (mapIndex == 0)
        {
            mapIndex = 3;
        }
        else
        {
            mapIndex--;
        }
        DispMap();
    }
}
