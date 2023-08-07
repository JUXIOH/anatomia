using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    public int testSubjectID = 0;
    public bool emptySlot = true;
    public string username = "N/A";
    public bool tutorialLevel = false;
    public int currency = 0;
    public int maxSanity = 3;

    public void Awake()
    {
        LoadPlayer();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayerTwo(this);
    }

    public void LoadPlayer()
    {
        PlayerTwoData data = SaveSystem.LoadPlayerTwo();

        testSubjectID = data.testSubjectID;
        emptySlot = data.emptySlot;
        username = data.username;
        tutorialLevel = data.tutorialLevel;
        currency = data.currency;
        maxSanity = data.maxSanity;
    }
}
