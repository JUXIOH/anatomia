using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerOneData
{
    public bool emptySlot;
    public string username;
    public bool tutorialLevel;

    public PlayerOneData(PlayerOne player)
    {
        emptySlot = player.emptySlot;
        username = player.username;
        tutorialLevel = player.tutorialLevel;
    }
}
