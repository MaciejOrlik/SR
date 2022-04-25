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
    private GameObject Player;




    public GameObject finish;
    public GameObject check1;
    public GameObject check2;
    public GameObject check3;
    public GameObject check4;
    public GameObject check5;
    public GameObject check6;
    public GameObject check7;
    public GameObject check8;

    private void Awake()
    {
        car = CarSave.CrLoad();
        switch (car.Index)
        {
            case 0:
                Player = Instantiate(Focus, SpawnPlace.transform.position, SpawnPlace.transform.rotation);
                break;
            case 1:
                Player = Instantiate(Supra, SpawnPlace.transform.position, SpawnPlace.transform.rotation);
                break;
            case 2:
                Player = Instantiate(Mercedes, SpawnPlace.transform.position, SpawnPlace.transform.rotation);
                break;
            case 3:
                Player = Instantiate(Porche, SpawnPlace.transform.position, SpawnPlace.transform.rotation);
                break;
            default:
                break;
        }
    }


    void Update()
    {
        if (Input.GetButtonDown("Reset"))
        {
            
            if (check1.activeSelf)
            {
                Player.transform.position = finish.transform.position;
                Player.transform.rotation = Quaternion.Euler(0,-15,0);
            }
            if (check2.activeSelf)
            {
                Player.transform.position = check1.transform.position;
                Player.transform.rotation = Quaternion.Euler(0, 101.37f, 0);
            }
            if (check3.activeSelf)
            {
                Player.transform.position = check2.transform.position;
                Player.transform.rotation = Quaternion.Euler(0, 128.9f, 0);
            }
            if (check4.activeSelf)
            {
                Player.transform.position = check3.transform.position;
                Player.transform.rotation = Quaternion.Euler(0, 196.8f, 0);
            }
            if (check5.activeSelf)
            {
                Player.transform.position = check4.transform.position;
                Player.transform.rotation = Quaternion.Euler(0, -152.2f, 0);
            }
            if (check6.activeSelf)
            {
                Player.transform.position = check5.transform.position;
                Player.transform.rotation = Quaternion.Euler(0, 1.49f, 0);
            }
            if (check7.activeSelf)
            {
                Player.transform.position = check6.transform.position;
                Player.transform.rotation = Quaternion.Euler(0, -107.6f, 0);
            }
            if (check8.activeSelf)
            {
                Player.transform.position = check7.transform.position;
                Player.transform.rotation = Quaternion.Euler(0, -9.63f, 0);
            }
            if (finish.activeSelf)
            {
                Player.transform.position = check8.transform.position;
                Player.transform.rotation = Quaternion.Euler(0, 77f, 0);
            }

        }
        

    }
}
