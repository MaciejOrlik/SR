using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreShow : MonoBehaviour
{
    public Text total;
    public Text place;
    public Text coins;

    public GameObject pauzy;
    public Text[] names;
    public Text[] cars;
    public Text[] times;
    public int nr_mapy;

    ScoreData sd;
    public LapComplete lc;
    private CarData cd;
    private int miejsce = 7;

    private bool raz = true;

    public InputField inputField;
    public Text input;

    public Text currentMoney;
    public Text gatheredMoney;
    private int zdobyteMonety = 0;
    int breakcoin = 0;

    private void Start()
    {
        cd = CarSave.CrLoad();
        sd = ScoreSave.SdLoad();
        wczytanieDanych();
        breakcoin = 0;
    }
    
    private void Update()
    {
        currentMoney.text = cd.getMoney().ToString();

        


        if (raz)
        {
            
            miejsce = podajmiejsce();
            zdobyteMonety = lc.sendCoin();
            zdobyteMonety = zdobyteMonety * 5;


            pauzy.SetActive(false);

            if (miejsce < 8)
            {
                for (int i = 7; i > miejsce; i--)
                {
                    names[i].text = names[i - 1].text;
                    cars[i].text = cars[i - 1].text;
                    times[i].text = times[i - 1].text;
                }


                //wpisz mnie
                if (cd.Index == 0)
                    cars[miejsce].text = "TOCUS";
                else if (cd.Index == 1)
                    cars[miejsce].text = "KUPRA";
                else if (cd.Index == 2)
                    cars[miejsce].text = "BOSSCAR";
                else if (cd.Index == 3)
                    cars[miejsce].text = "SUPERCAR";

                times[miejsce].text = lc.sendTime();
                
                Debug.Log("zmiana");
                
                raz = false;
                inputField.ActivateInputField();

                gatheredMoney.text = "+ " + ((9 - miejsce - 1) * 63 + zdobyteMonety + 100);
                cd.addMoney(((9 - miejsce - 1) * 63 + zdobyteMonety + 100));

                place.text = "+ " + ((9 - miejsce - 1) * 63 + 100).ToString();
                total.text = "+ " + ((9 - miejsce - 1) * 63 + zdobyteMonety + 100);
                coins.text = "+ " + zdobyteMonety.ToString();
            }
            else if (breakcoin == 0)
            {
                gatheredMoney.text = "+ " + zdobyteMonety;
                cd.addMoney(zdobyteMonety + 100);
                breakcoin++;
                raz = false;

                place.text = "+ 100";
                total.text = "+ " + zdobyteMonety;
                coins.text = "+ " + zdobyteMonety.ToString();
            }


        }
        if (miejsce<8)
        {
            names[miejsce].text = input.text;
        }
               
    }
    private void wczytanieDanych()
    {
        for (int i = 0; i < 8; i++)
        {
            names[i].text = sd.wynik[nr_mapy - 1, i, 0];
            cars[i].text = sd.wynik[nr_mapy - 1, i, 1];
            times[i].text = sd.wynik[nr_mapy - 1, i, 2];
        }
    }
    
   public int podajmiejsce()
    {
        int temp = 9;
        
        for (int i = 0; i < 8; i++)
        {
            if (DateTime.Parse("00:" + lc.sendTime()) < DateTime.Parse("00:" + times[i].text))
            {
                temp = i;
                break;
            }
        }
        return temp;
    }

    public void zapiszTabliceWynikow()
    {
        for (int i = 0; i < 8; i++)
        {
            sd.wynik[nr_mapy - 1, i, 0] = names[i].text;
            sd.wynik[nr_mapy - 1, i, 1] = cars[i].text;
            sd.wynik[nr_mapy - 1, i, 2] = times[i].text;
        }
        CarSave.CrSave(cd);
        ScoreSave.SdSave(sd);
        Debug.LogWarning("ejno");

    }
}
