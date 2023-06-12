using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayers : MonoBehaviour
{
    PlayerOne user1;

    private void Start()
    {
        user1 = GetComponent<PlayerOne>();
    }

    public void resetAll()
    {
        user1.emptySlot = true;
        user1.username = "NA";
        user1.tutorialLevel = false;
        user1.SavePlayer();
    }
}
