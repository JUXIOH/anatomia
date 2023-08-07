using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayers : MonoBehaviour
{
    PlayerOne user1;
    PlayerTwo user2;
    PlayerThree user3;

    private void Start()
    {
        user1 = GetComponent<PlayerOne>();
        user2 = GetComponent<PlayerTwo>();
        user3 = GetComponent<PlayerThree>();
    }

    public void resetAll()
    {
        user1.emptySlot = true;
        user1.username = "NA";
        user1.tutorialLevel = false;
        user1.SavePlayer();

        user2.emptySlot = true;
        user2.username = "NA";
        user2.tutorialLevel = false;
        user2.SavePlayer();

        user3.emptySlot = true;
        user3.username = "NA";
        user3.tutorialLevel = false;
        user3.SavePlayer();
    }
}
