using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : MonoBehaviour
{
    public Button user1;
    public TMPro.TMP_InputField user1inp;
    public TMPro.TMP_Text user1Name;
    public TMPro.TMP_Text user1NameLoad;

    private PlayerOne userOne;

    private LevelLoader level;

    private void Awake()
    {
        level = FindObjectOfType<LevelLoader>();

        userOne = GetComponent<PlayerOne>();
    }

    private void Update()
    {
        if (userOne.emptySlot == false)
        {
            user1.interactable = false;
        }
        else
        {
            user1.interactable = true;
        }

        user1Name.text = userOne.username;
        user1NameLoad.text = userOne.username;
    }

    public void newGame(int x)
    {
        string username = user1inp.text.ToString();

        switch (x)
        {
            case 1:
                if(!string.IsNullOrEmpty(username))
                {
                    userOne.emptySlot = false;
                    userOne.username = username;
                    userOne.SavePlayer();
                    level.LoadLevel(1);
                }
                break;
        }
    }

    public void loadGame(int x)
    {
        switch (x)
        {
            case 1:
                if(userOne.tutorialLevel == false)
                {
                    level.LoadLevel(1);
                }
                else
                {
                    level.LoadLevel(2);
                }
                break;
        }
    }
}
