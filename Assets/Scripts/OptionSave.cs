using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class OptionSave
{
    // ZAPIS I ODCZYT PLIKU Z KLASA OptionData.cs
    public static OptionData OpLoad()
    {
        string path = Application.persistentDataPath + "/options.sr";   // %appdata%/localLow/DefaultCompany/SR/options.sr
        if (File.Exists(path))                                          // jesli plik istnieje -> wczytaj
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            OptionData data = formatter.Deserialize(fileStream) as OptionData;
            fileStream.Close();

            Debug.Log("Wczytano");
            return data;
        }
        else // Jesli nie istneje to default
        {
            OptionData data = new OptionData();

            Debug.Log("Noup");
            return data;
        }
    }

    public static void OpSave (OptionData OD)   //zapisuje klase w %appdata%/localLow/DefaultCompany/SR/options.sr
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/options.sr";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, OD);
        fileStream.Close();
    }
}
