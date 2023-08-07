using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerThreeData
{
    public int testSubjectID;
    public bool emptySlot;
    public string username;
    public bool tutorialLevel;
    public int currency;
    public int maxSanity;

    public PlayerThreeData(PlayerThree player)
    {
        testSubjectID = player.testSubjectID;
        emptySlot = player.emptySlot;
        username = player.username;
        tutorialLevel = player.tutorialLevel;
        currency = player.currency;
        maxSanity = player.maxSanity;
    }
}
