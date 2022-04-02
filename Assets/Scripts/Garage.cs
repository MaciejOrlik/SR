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
    public GameObject Porshe;   
    public GameObject Mercedes;
    public GameObject Focus;
    public GameObject Supra;
    private int carIndex = 0;
    //CAR STATS
    /*private float engineValue = 0f;
    private float nitroValue = 0f;
    private float brakeValue = 0f;*/

    private float[] engineValue = { 0f, 0f, 0f, 0f };
    private float[] nitroValue = { 0f, 0f, 0f, 0f };
    private float[] brakeValue = { 0f, 0f, 0f, 0f };

    public CarData car = CarSave.CrLoad();
    
    void Start()
    {
        carSelect();
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
        Porshe.SetActive(false);
        Focus.SetActive(false);
        switch (carIndex) //Uzueplnic .setActive
        {
            case 0:
                Focus.SetActive(true);
                break;
            case 1:
                Supra.SetActive(true);
                break;
            case 2:
                Mercedes.SetActive(true);
                break;
            case 3:
                Porshe.SetActive(true);
                break;
            default:
                break;
        }
        setAll();
    }
    // ZMIANA SCEN
    public void sceneMap ()
    {
        CarSave.CrSave(car);
        SceneManager.LoadScene("Map_Select");
    }
    public void sceneShop ()
    {
        CarSave.CrSave(car);
        SceneManager.LoadScene("Shop");
    }
    public void sceneMenu ()
    {
        CarSave.CrSave(car);
        SceneManager.LoadScene("Menu");
    }
    public void quit()
    {
        CarSave.CrSave(car);
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


    // ---------------------------------------------------  ULEPSZANIE ----------------------------------- //
    /*
    public void ulepszSilnik()
    {
        if (car.carUpgrade[car.carIndex, 0] < 2)
        {
            car.carUpgrade[car.carIndex, 0]++;
        }
        engineValue = (car.carPW() - 
            car.carPower[car.carIndex, 0])/50;
        setEngine();
    }
    */
    public void ulepszNitro()
    {
        if(nitroValue[carIndex]<1f)
        {
            nitroValue[carIndex] = nitroValue[carIndex] + 0.34f;
            setNitro();

        }
    }

    public void ulepszHamulce()
    {
        if (brakeValue[carIndex] < 1f)
        {
            brakeValue[carIndex] = brakeValue[carIndex] + 0.34f;
            setBrake();

        }
    }
    
}
