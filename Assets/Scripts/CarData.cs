using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarData
{
    public int Money;
    public int Index;//                           0-Focus 1-Supra 2-Merc 3-Lambo
    public int[,] Upgrade = new int[4,3];//       V - Upgrade number (0-2)   1-CarIndex 2-UpgradeType(engine|nitro|brake)
    private float[,] carPower;// new float[4,3];      V - Upgrade value (50-200) 1-CarIndex 2-carUpgradeNumber (0-2)
    private float[,] carNitro;// new float[4,3];      V - Upgrade value (50-200) 1-CarIndex 2-carUpgradeNumber (0-2)
    private float[,] carBrake;// new float[4,3];      V - Upgrade value (50-400) 1-CarIndex 2-carUpgradeNumber (0-2)
    public bool[] carHave;   // new bool[4];         V - Do you have that car
    

    public CarData ()
    {

        Money = 0;
        Index = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Upgrade[i,j] = 0;
            }
        }    
        carPower = new float[,] { { 50f, 75f, 100f }, { 75f, 100f, 125f }, { 100f, 125f, 150f }, { 150f, 175f, 200f } };
        carNitro = new float[,] { { 50f, 150f, 250f }, { 100f, 200f, 300f }, { 150f, 250f, 350f }, { 200f, 300f, 400f } };
        carBrake = new float[,] { { 12000f, 60000f, 120000f }, { 12000f, 60000f, 120000f }, { 12000f, 60000f, 120000f }, { 12000f, 60000f, 120000f } };
        carHave = new bool[] { true, false, false, false };
    }

    public float getPower() { return carPower[Index, Upgrade[Index,0]]; }
    public float getNitro() { return carNitro[Index, Upgrade[Index,1]]; }
    public float getBrake() { return carBrake[Index, Upgrade[Index,2]]; }

    public float getPower(int indx) { return carPower[indx, Upgrade[indx, 0]]; }
    public float getNitro(int indx) { return carNitro[indx, Upgrade[indx, 1]]; }
    public float getBrake(int indx) { return carBrake[indx, Upgrade[indx, 2]]; }


    public float getPowerStock() { return carPower[Index, 0]; }
    public float getNitroStock() { return carNitro[Index, 0]; }
    public float getBrakeStock() { return carBrake[Index, 0]; }

    public float getPowerStock(int indx) { return carPower[indx, 0]; }
    public float getNitroStock(int indx) { return carNitro[indx, 0]; }
    public float getBrakeStock(int indx) { return carBrake[indx, 0]; }


    public float getPowerPercent() { float temp = (float)getUpgradePower(Index); return temp / 2; }
    public float getNitroPercent() { float temp = (float)getUpgradeNitro(Index); return temp / 2; }
    public float getBrakePercent() { float temp = (float)getUpgradeBrake(Index); return temp / 2; }


    public float getPowerPercent(int indx) { float temp = (float)getUpgradePower(indx); return temp / 2; }
    public float getNitroPercent(int indx) { float temp = (float)getUpgradeNitro(indx); return temp / 2; }
    public float getBrakePercent(int indx) { float temp = (float)getUpgradeBrake(indx); return temp / 2; }

    public void upgradePower() { if (Upgrade[Index, 0] < 2) {Upgrade[Index, 0]++; } }
    public void upgradeNitro() { if (Upgrade[Index, 1] < 2) {Upgrade[Index, 1]++;} }
    public void upgradeBrake() { if (Upgrade[Index, 2] < 2) {Upgrade[Index, 2]++;} }

    public void upgradePower(int indx) { if (Upgrade[indx, 0] < 2) {Upgrade[indx, 0]++;} }
    public void upgradeNitro(int indx) { if (Upgrade[indx, 1] < 2) {Upgrade[indx, 1]++;} }
    public void upgradeBrake(int indx) { if (Upgrade[indx, 2] < 2) {Upgrade[indx, 2]++;} }


    public int getUpgradePower(int indx) { return Upgrade[indx,0]; }
    public int getUpgradeNitro(int indx) { return Upgrade[indx,1]; }
    public int getUpgradeBrake(int indx) { return Upgrade[indx,2]; }

    public int getUpgradePower() { return Upgrade[Index, 0]; }
    public int getUpgradeNitro() { return Upgrade[Index, 1]; }
    public int getUpgradeBrake() { return Upgrade[Index, 2]; }


    public bool haveCar() { return carHave[Index]; }
    public bool haveCar(int indx) { return carHave[indx]; }

    public void setCar(bool set) { carHave[Index] = set; }
    public void setCar(bool set, int indx) { carHave[indx] = set; }

    public int getMoney() { return Money;  }
    public void addMoney(int amount) { Money += amount;  }
    public void subtractMoney(int amount) { Money -= amount; }

}
