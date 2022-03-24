using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smooth = 0.3f;
    public float distance = 5.0f;
    public float height = 1.0f;
    public float Angle = 20;


    public CarUIClass CarUI;



    private float yVelocity = 0.0f;
    private float xVelocity = 0.0f;
    [HideInInspector]
    public int Switch;

    private int gearst = 0;
    private float thisAngle = -150;
    private float restTime = 0.0f;


    private Rigidbody myRigidbody;



    private VehicleControl carScript;



    [System.Serializable]
    public class CarUIClass
    {
        public Image tachometerNeedle;
        public Image barShiftGUI;

        public Text speedText;
        public Text GearText;
    }




    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public void ShowCarUI()
    {

        //przypisanie biegu do UI
        gearst = carScript.currentGear;
        CarUI.speedText.text = ((int)carScript.speed).ToString();

        if (gearst > 0 && carScript.speed > 1)
        {
            CarUI.GearText.color = Color.green;
            CarUI.GearText.text = gearst.ToString();
        }
        else if (carScript.speed > 1)
        {
            CarUI.GearText.color = Color.red;
            CarUI.GearText.text = "R";
        }
        else
        {
            CarUI.GearText.color = Color.white;
            CarUI.GearText.text = "N";
        }

        
        //UI nitra i wskaŸnika prêdokoœci
        thisAngle = (carScript.motorRPM / 20) - 175;
        thisAngle = Mathf.Clamp(thisAngle, -180, 90);

        CarUI.tachometerNeedle.rectTransform.rotation = Quaternion.Euler(0, 0, -thisAngle);
        CarUI.barShiftGUI.rectTransform.localScale = new Vector3(carScript.powerShift / 100.0f, 1, 1);

    }



    void Start()
    {
        carScript = (VehicleControl)target.GetComponent<VehicleControl>();

        myRigidbody = target.GetComponent<Rigidbody>();

    }




    void Update()
    {

        if (!target) return;


        carScript = (VehicleControl)target.GetComponent<VehicleControl>();

        if (restTime != 0.0f)
            restTime = Mathf.MoveTowards(restTime, 0.0f, Time.deltaTime);


        ShowCarUI();

        GetComponent<Camera>().fieldOfView = Mathf.Clamp(carScript.speed / 10.0f + 60.0f, 60, 90.0f);




        // Damp angle from current y-angle towards target y-angle

        float xAngle = Mathf.SmoothDampAngle(transform.eulerAngles.x,
        target.eulerAngles.x + Angle, ref xVelocity, smooth);

        float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
        target.eulerAngles.y, ref yVelocity, smooth);

        // Look at the target
        transform.eulerAngles = new Vector3(xAngle, yAngle, 0.0f);

        var direction = transform.rotation * -Vector3.forward;
        var targetDistance = AdjustLineOfSight(target.position + new Vector3(0, height, 0), direction);


        transform.position = target.position + new Vector3(0, height, 0) + direction * targetDistance;

    }


    float AdjustLineOfSight(Vector3 target, Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(target, direction, out hit, distance, 0))
            return hit.distance;
        else
            return distance;
    }
}
