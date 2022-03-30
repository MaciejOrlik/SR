using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Garage : MonoBehaviour
{
    public Image engineFill;
    public Image nitroFill;
    public Image brakeFill;

    public Slider engineSlider;
    public Slider nitroSlider;
    public Slider brakeSlider;

    private int carIndex;

    private float engineValue;
    private float nitroValue;
    private float brakeValue;
    void Start()
    {
        setEngine();
        setNitro();
        setBrake();
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
        switch (carIndex) //Uzueplnic .setActive
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            default:
                break;
        }

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
    public void setEngine ()
    {
        engineFill.fillAmount = engineSlider.value;
    }
    public void setNitro ()
    {
        nitroFill.fillAmount = nitroSlider.value;
    }
    public void setBrake ()
    {
        brakeFill.fillAmount = brakeSlider.value;
    }

    public void IncQual() //carIndex ++
    {
        if (carIndex < 2)
        {
            carIndex++;
        }
        else
        {
            carIndex = 0;
        }
        carSelect();
    }

    public void DecQual() // carIndex --
    {
        if (carIndex == 0)
        {
            carIndex = 2;
        }
        else
        {
            carIndex--;
        }
        carSelect();
    }
}
