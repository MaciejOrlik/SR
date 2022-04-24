using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    private string[] carNames = { "TOCUS", "KUPRA", "BOSSCAR", "SUPERCAR" };
    public int[] carPrice = { 0, 0, 0, 0 };
    private CarData car;


    public GameObject Porshe;
    public GameObject Mercedes;
    public GameObject Focus;
    public GameObject Supra;

    public Button buyButton;
    public TextMeshProUGUI buyText;

    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI priceTag;


    private void Start()
    {
        car = CarSave.CrLoad();
        carSelect();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            CarSave.CrSave(car);
            SceneManager.LoadScene("Garage");
        }
    }

    public void Buy()
    {
        car.setCar(true);
        carSelect();
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

        buyButton.interactable = !car.haveCar();
        buyText.text = car.haveCar() ? "Already bought" : "BUY";
        buyText.color = car.haveCar()? Color.grey : Color.white;

        nameTag.text = carNames[car.Index];
        priceTag.text = carPrice[car.Index].ToString();
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

    public void Back()
    {
        CarSave.CrSave(car);
        SceneManager.LoadScene("Garage");
    }

}



