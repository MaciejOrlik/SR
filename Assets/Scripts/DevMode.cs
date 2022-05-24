using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DevMode : MonoBehaviour
{
    private CarData cd;
    public GameObject inputfield;
    public Text inputtext;
    public GameObject btn;

    private bool q = false, w = false, e = false, r = false, t = false, y = false;
    private void Start()
    {
        cd = CarSave.CrLoad();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            q = true;
        }

        if (q && Input.GetKey(KeyCode.E))
        {
            w = true;
        }

        if (w && Input.GetKey(KeyCode.Z))
        {
            e = true;
        }

        if (e && Input.GetKey(KeyCode.A))
        {
            r = true;
        }

        if (r && Input.GetKey(KeyCode.K))
        {
            t = true;
        }

        if (t && Input.GetKey(KeyCode.M))
        {
            y = true;
        }

        if (y && Input.GetKey(KeyCode.I))
        {
            inputfield.SetActive(true);
            btn.SetActive(true);
        }
    }

    public void add()
    {
        int n = 0;
        if (int.TryParse(inputtext.text, out n))
        {
            if(n != 0)
            {
                cd.addMoney(n);
            }
            else
            {
                cd.subtractMoney(cd.getMoney());
            }
            CarSave.CrSave(cd);
        }
    }
}
