using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawn : MonoBehaviour
{
    private CarData car;

    public GameObject SpawnPlace;

    public GameObject Focus;
    public GameObject Supra;
    public GameObject Mercedes;
    public GameObject Porche;

    void Start()
    {
        car = CarSave.CrLoad();
        switch (car.Index)
        {
            case 0:
                Instantiate(Focus, SpawnPlace.transform.position, Quaternion.identity);
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


    void Update()
    {
        
    }
}
