using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MapSelect : MonoBehaviour
{
    public TextMeshProUGUI mapName;
    private string[] mapNames = { "Countryside", "Snowcircle", "Dusty Castles", "Big Farms" };
    private int mapIndex = 0;

    public GameObject i1,i2,i3,i4;
    public RawImage ri;
    public Texture t1,t2,t3,t4;
    public Image image;

    private void Start()
    {
        DispMap();
    }
    private void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("Garage");
        }
        
        if(mapIndex==0)
        {
            i1.SetActive(true);
            i2.SetActive(false);
            i3.SetActive(false);
            i4.SetActive(false);

            ri.texture = t1;
            image.GetComponent<Image>().color = new Color32(48, 255, 7, 225);

        }
        else if(mapIndex == 1)
        {
            i2.SetActive(true);
            i1.SetActive(false);
            i3.SetActive(false);
            i4.SetActive(false);

            ri.texture = t2;

            image.GetComponent<Image>().color = new Color32(6, 43, 225, 225);

        }
        else if (mapIndex == 2)
        {
            i3.SetActive(true);
            i1.SetActive(false);
            i2.SetActive(false);
            i4.SetActive(false);

            ri.texture = t3;

            image.GetComponent<Image>().color = new Color32(255, 130, 6, 225);

        }
        else
        {
            i4.SetActive(true);
            i1.SetActive(false);
            i2.SetActive(false);
            i3.SetActive(false);

            ri.texture = t4;

            image.GetComponent<Image>().color = new Color32(255, 255, 255, 225);

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
