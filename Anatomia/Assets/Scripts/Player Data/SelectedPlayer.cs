using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPlayer : MonoBehaviour
{
    public int testSubjectID = 0;
    public string username = "N/A";
    public int currency = 0;
    public int maxSanity = 3;

    public void Awake()
    {
        LoadPlayer();
    }

    public void SavePlayer()
    {
        SaveSystem.SaveSelectedPlayer(this);
    }

    public void LoadPlayer()
    {
        SelectedPlayerData data = SaveSystem.LoadSelectedPlayer();

        testSubjectID = data.testSubjectID;
        username = data.username;
        currency = data.currency;
        maxSanity = data.maxSanity;
    }
}
