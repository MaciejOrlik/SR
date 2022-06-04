using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyColor : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public Material material;
    public Material material1;
    public Material material2;
    public Material material3;

    public GameObject canvas;
    

    public GameObject car;
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;

    public Material basematerial;
    public Material basematerial1;
    public Material basematerial2;
    public Material basematerial3;

  
    // Update is called once per frame
    void Update()
    {
        if(car.activeSelf == true)
        {
           material.color = fcp.color;
        }
        if (car1.activeSelf == true)
        {
            material1.color = fcp.color;
        }
        if (car2.activeSelf == true)
        {
            material2.color = fcp.color;
        }
        if (car3.activeSelf == true)
        {
            material3.color = fcp.color;
        }
    }

    public void OnColor()
    {
        if(canvas.activeSelf == true)
        {
            canvas.SetActive(false);
        }
        if (canvas.activeSelf == false)
        {
            canvas.SetActive(true);
        }
    }

    public void Setbasematerial()
    {
        if (car.activeSelf == true)
        {
            fcp.color = basematerial.color;
        }
        if (car1.activeSelf == true)
        {
            fcp.color = basematerial1.color;
        }
        if (car2.activeSelf == true)
        {
            fcp.color = basematerial2.color;
        }
        if (car3.activeSelf == true)
        {
            fcp.color = basematerial3.color;
        }        
    }
}
