using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public bool emptySlot = true;
    public string username = "N/A";
    public bool tutorialLevel = false;

    public void Awake()
    {
        LoadPlayer();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayerOne(this);
    }

    public void LoadPlayer()
    {
        PlayerOneData data = SaveSystem.LoadPlayerOne();

        emptySlot = data.emptySlot;
        username = data.username;
        tutorialLevel = data.tutorialLevel;
    }
}
