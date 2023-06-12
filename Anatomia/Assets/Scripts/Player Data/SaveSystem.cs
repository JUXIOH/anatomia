using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayerOne(PlayerOne player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerone.sui";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerOneData data = new PlayerOneData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerOneData LoadPlayerOne()
    {
        string path = Application.persistentDataPath + "/playerone.sui";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerOneData data = formatter.Deserialize(stream) as PlayerOneData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
