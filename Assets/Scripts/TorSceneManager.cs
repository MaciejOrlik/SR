using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TorSceneManager : MonoBehaviour
{
    /*CarData car = CarSave.CrLoad();
    private GameObject Focus;
    
    private void Start()
    {
        if (car.carIndex == 0)
        {
            Focus = Instantiate(Focus,new Vector3(452f,17f,208f),Quaternion.identity);
        }
    }*/


    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Garage");
        }
    }
}
