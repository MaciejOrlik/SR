using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Garage : MonoBehaviour
{
    //CAR STAT GRAPHIC VALUE
    public Image engineFill;
    public Image nitroFill;
    public Image brakeFill;
    //CARS
    public GameObject Porche;   
    public GameObject Mercedes;
    public GameObject Focus;
    public GameObject Supra;
    private int carIndex;
    //CAR STATS
    private float[] engineValue = { 0.5f, 0.7f, 0.9f, 0.2f };
    private float[] nitroValue = { 0f, 0.2f, 0.8f, 0f };
    private float[] brakeValue = { 0.25f, 0.5f, 0.75f, 0.2f };

    void Start()
    {
        setAll();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) // ESC hierarchi MENU <- GARAZ <- INNE OKNA
        {
            SceneManager.LoadScene("Menu");
        }



    }

    public void carSelect() // wybor samochodu na podstawie indexu <0,3>
    {
        Mercedes.SetActive(false);
        Supra.SetActive(false);
        Porche.SetActive(false);
        Focus.SetActive(false);
        switch (carIndex) //Uzueplnic .setActive
        {
            case 0:
                Mercedes.SetActive(true);
                break;
            case 1:
                Supra.SetActive(true);
                break;
            case 2:
                Porche.SetActive(true);
                break;
            case 3:
                Focus.SetActive(true);
                break;
            default:
                break;
        }
        setAll();
    }
    // ZMIANA SCEN
    public void sceneMap ()
    {
        SceneManager.LoadScene("Map_Select");
    }
    public void sceneShop ()
    {
        SceneManager.LoadScene("Shop");
    }
    public void sceneMenu ()
    {
        SceneManager.LoadScene("Menu");
    }
    public void quit()
    {
        Application.Quit();
    }    
        
    // USTAWIANIE WARTOSCI STATYSTYK 
    private void setEngine ()
    {
        engineFill.fillAmount = engineValue[carIndex];
    }
    private void setNitro ()
    {
        nitroFill.fillAmount = nitroValue[carIndex];
    }
    private void setBrake ()
    {
        brakeFill.fillAmount = brakeValue[carIndex];
    }
    public void setAll ()
    {
        setEngine();
        setNitro();
        setBrake();
    }

    public void IncCar() //carIndex ++
    {
        if (carIndex < 3)
        {
            carIndex++;
        }
        else
        {
            carIndex = 0;
        }
        carSelect();
    }

    public void DecCar() // carIndex --
    {
        if (carIndex == 0)
        {
            carIndex = 3;
        }
        else
        {
            carIndex--;
        }
        carSelect();
    }
}
