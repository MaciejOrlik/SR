using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class CarSave
{
    // ZAPIS I ODCZYT PLIKU Z KLASA CarData.cs
    public static CarData CrLoad()
    {
        string path = Application.persistentDataPath + "/Cars.sr";   // %appdata%/localLow/DefaultCompany/SR/Cars.sr
        if (File.Exists(path))                                          // jesli plik istnieje -> wczytaj
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            CarData data = formatter.Deserialize(fileStream) as CarData;
            fileStream.Close();

            Debug.Log("Wczytano");
            return data;
        }
        else // Jesli nie istneje to default
        {
            CarData data = new CarData();

            Debug.Log("Noup");
            return data;
        }
    }

    public static void CrSave(CarData Car)   //zapisuje klase w %appdata%/localLow/DefaultCompany/SR/Cars.sr
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Cars.sr";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, Car);
        fileStream.Close();
    }
}

