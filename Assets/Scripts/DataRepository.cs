using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataRepository
{
    public void SaveGame(GameData data)
    {
        // Save the game data
        var filePath = Application.persistentDataPath + "/ninpulpData.dat";
        FileStream file;

        if (File.Exists(filePath))
        {
            file = File.OpenWrite(filePath);
        }
        else
        {
            file = File.Create(filePath);
        }

        var formatter = new BinaryFormatter();
        formatter.Serialize(file, data);
        Debug.Log(Application.persistentDataPath);
        file.Close();
    }

    public GameData LoadGame()
    {
        var filePath = Application.persistentDataPath + "/ninpulpData.dat";
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            var file = File.OpenRead(filePath);
            var formatter = new BinaryFormatter();
            var data = (GameData)formatter.Deserialize(file);
            file.Close();
            return data;
        }
        else
        {
            return new GameData();
        }

    }
}
