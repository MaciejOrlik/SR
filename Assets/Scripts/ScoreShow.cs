using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    public Text[] names;
    public Text[] cars;
    public Text[] times;
    public int nr_mapy;

    ScoreData sd = new ScoreData();



    private void Start()
    {
        for(int i=0; i<8;i++)
        {
            names[i].text = sd.wynik[nr_mapy-1, i, 0];
            cars[i].text = sd.wynik[nr_mapy - 1, i, 1];
            times[i].text = sd.wynik[nr_mapy - 1, i, 2];
        }
    }

    
}
