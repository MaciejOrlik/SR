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

    private void Awake()
    {
        car = CarSave.CrLoad();
        switch (car.Index)
        {
            case 0:
                Instantiate(Focus, SpawnPlace.transform.position, SpawnPlace.transform.rotation);
                break;
            case 1:
                Instantiate(Supra, SpawnPlace.transform.position, SpawnPlace.transform.rotation);
                break;
            case 2:
                Instantiate(Mercedes, SpawnPlace.transform.position, SpawnPlace.transform.rotation);
                break;
            case 3:
                Instantiate(Porche, SpawnPlace.transform.position, SpawnPlace.transform.rotation);
                break;
            default:
                break;
        }
    }


    void Update()
    {
        
    }
}
