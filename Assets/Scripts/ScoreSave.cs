using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class ScoreSave
{
    // ZAPIS I ODCZYT PLIKU Z KLASA CarData.cs
    public static ScoreData SdLoad()
    {
        string path = Application.persistentDataPath + "/Leaderboard.sr";   // %appdata%/localLow/DefaultCompany/SR/Cars.sr
        if (File.Exists(path))                                          // jesli plik istnieje -> wczytaj
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(fileStream) as ScoreData;
            fileStream.Close();

            Debug.Log("Wczytano");
            return data;
        }
        else // Jesli nie istneje to default
        {
            ScoreData data = new ScoreData();

            Debug.Log("Noup");
            return data;
        }
    }

    public static void SdSave(ScoreData Score)   //zapisuje klase w %appdata%/localLow/DefaultCompany/SR/Cars.sr
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Leaderboard.sr";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        formatter.Serialize(fileStream, Score);
        fileStream.Close();
    }
}

