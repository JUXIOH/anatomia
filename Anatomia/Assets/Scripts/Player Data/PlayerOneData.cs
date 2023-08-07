using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerOneData
{
    public int testSubjectID;
    public bool emptySlot;
    public string username;
    public bool tutorialLevel;
    public int currency;
    public int maxSanity;

    public PlayerOneData(PlayerOne player)
    {
        testSubjectID = player.testSubjectID;
        emptySlot = player.emptySlot;
        username = player.username;
        tutorialLevel = player.tutorialLevel;
        currency = player.currency;
        maxSanity = player.maxSanity;
    }
}
