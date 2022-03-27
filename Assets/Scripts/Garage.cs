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
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }    
    }

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
}
