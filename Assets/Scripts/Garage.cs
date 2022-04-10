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
    //CAR STATS
    private float engineValue = 0f;
    private float nitroValue = 0f;
    private float brakeValue = 0f;

    public CarData car;

    void Start()
    {
        car = CarSave.CrLoad();
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
        switch (car.Index) 
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
    public void revertUpgrade()
    {
        car.Upgrade[car.Index, 0] = 0;
        car.Upgrade[car.Index, 1] = 0;
        car.Upgrade[car.Index, 2] = 0;
        setAll();
    }
    public void quit()
    {
        CarSave.CrSave(car);
        Application.Quit();
    }    

    public void setAll ()
    {
        engineValue = car.getPowerPercent();
        nitroValue = car.getNitroPercent();
        brakeValue = car.getBrakePercent();

        engineFill.fillAmount = engineValue;
        nitroFill.fillAmount = nitroValue;
        brakeFill.fillAmount = brakeValue;
    }

    public void IncCar() //carIndex ++
    {
        if (car.Index < 3)
        {
            car.Index++;
        }
        else
        {
            car.Index = 0;
        }
        carSelect();
    }

    public void DecCar() // carIndex --
    {
        if (car.Index == 0)
        {
            car.Index = 3;
        }
        else
        {
            car.Index--;
        }
        carSelect();
    }


    // ---------------------------------------------------  ULEPSZANIE ----------------------------------- //

    public void ulepszSilnik() 
    {
        CarSave.CrSave(car);
        car.upgradePower();
        setAll();
    }

    public void ulepszNitro() 
    {
        CarSave.CrSave(car);
        car.upgradeNitro();
        setAll();
    }

    public void ulepszHamulce() 
    {
        CarSave.CrSave(car);
        car.upgradeBrake(); 
        setAll();
    }
    
}
