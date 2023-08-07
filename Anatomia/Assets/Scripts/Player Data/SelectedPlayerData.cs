using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SelectedPlayerData
{
    public int testSubjectID;
    public string username;
    public int currency;
    public int maxSanity;

    public SelectedPlayerData(SelectedPlayer player)
    {
        testSubjectID = player.testSubjectID;
        username = player.username;
        currency = player.currency;
        maxSanity = player.maxSanity;
    }
}
