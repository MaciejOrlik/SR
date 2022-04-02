using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarData
{
    public int carIndex;//                           0-Focus 1-Supra 2-Merc 3-Lambo
    public int[,] carUpgrade = new int[4,3];//       V - Upgrade number (0-2)   1-CarIndex 2-UpgradeType(engine|nitro|brake)
    public float[,] carPower;// new float[4,3];      V - Upgrade value (50-200) 1-CarIndex 2-carUpgradeNumber (0-2)
    public float[,] carNitro;// new float[4,3];      V - Upgrade value (50-200) 1-CarIndex 2-carUpgradeNumber (0-2)
    public float[,] carBrake;// new float[4,3];      V - Upgrade value (50-400) 1-CarIndex 2-carUpgradeNumber (0-2)
    public bool[] carHave;   // new bool[4];         V - Do you have that car

    public CarData ()
    {
        carIndex = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                carUpgrade[i,j] = 0;
            }
        }    
        carPower = new float[,] { { 50f, 75f, 100f }, { 75f, 100f, 125f }, { 100f, 125f, 150f }, { 150f, 175f, 200f } };
        carNitro = new float[,] { { 50f, 150f, 250f }, { 100f, 200f, 300f }, { 150f, 250f, 350f }, { 200f, 300f, 400f } };
        carBrake = new float[,] { { 12000f, 60000f, 120000f }, { 12000f, 60000f, 120000f }, { 12000f, 60000f, 120000f }, { 12000f, 60000f, 120000f } };
        carHave = new bool[] { true, false, false, false };
    }

    public float carPW()
    {
        return carPower[carIndex, carUpgrade[carIndex,0]];
    }
}
