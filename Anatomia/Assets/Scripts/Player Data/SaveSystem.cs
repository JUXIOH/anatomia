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

    public static void SavePlayerTwo(PlayerTwo player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playertwo.sui";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerTwoData data = new PlayerTwoData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerTwoData LoadPlayerTwo()
    {
        string path = Application.persistentDataPath + "/playertwo.sui";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerTwoData data = formatter.Deserialize(stream) as PlayerTwoData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static void SavePlayerThree(PlayerThree player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerthree.sui";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerThreeData data = new PlayerThreeData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerThreeData LoadPlayerThree()
    {
        string path = Application.persistentDataPath + "/playerthree.sui";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerThreeData data = formatter.Deserialize(stream) as PlayerThreeData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveSelectedPlayer(SelectedPlayer player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/selectedplayer.mikoti";
        FileStream stream = new FileStream(path, FileMode.Create);

        SelectedPlayerData data = new SelectedPlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SelectedPlayerData LoadSelectedPlayer()
    {
        string path = Application.persistentDataPath + "/selectedplayer.mikoti";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SelectedPlayerData data = formatter.Deserialize(stream) as SelectedPlayerData;
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
