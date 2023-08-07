using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : MonoBehaviour
{
    public AudioSource wrongAnswer;

    public Button user1;
    public Button user1Load;
    public Button user1Del;
    public TMPro.TMP_InputField user1inp;
    public TMPro.TMP_Text user1Name;
    public TMPro.TMP_Text user1NameLoad;
    public TMPro.TMP_Text user1Dialogue;
    public GameObject deleteBtn1;

    public Button user2;
    public Button user2Load;
    public Button user2Del;
    public TMPro.TMP_InputField user2inp;
    public TMPro.TMP_Text user2Name;
    public TMPro.TMP_Text user2NameLoad;
    public TMPro.TMP_Text user2Dialogue;
    public GameObject deleteBtn2;

    public Button user3;
    public Button user3Load;
    public Button user3Del;
    public TMPro.TMP_InputField user3inp;
    public TMPro.TMP_Text user3Name;
    public TMPro.TMP_Text user3NameLoad;
    public TMPro.TMP_Text user3Dialogue;
    public GameObject deleteBtn3;

    private PlayerOne userOne;
    private PlayerTwo userTwo;
    private PlayerThree userThree;

    public int currentTestSubjectID;

    private LevelLoader level;

    private int userLoaded;

    private void Awake()
    {
        level = FindObjectOfType<LevelLoader>();

        currentTestSubjectID = PlayerPrefs.GetInt("currentTestSubjectID");

        userOne = GetComponent<PlayerOne>();
        userTwo = GetComponent<PlayerTwo>();
        userThree = GetComponent<PlayerThree>();
    }

    private void Update()
    {
        LoadUsers();
    }

    public void DeleteUser(int x)
    {
        switch (x)
        {
            case 1:
                userOne.testSubjectID = 0;
                userOne.emptySlot = true;
                userOne.username = "N/A";
                userOne.tutorialLevel = false;
                userOne.currency = 100;
                userOne.maxSanity = 3;
                userOne.SavePlayer();
                break;
            case 2:
                userTwo.emptySlot = true;
                userTwo.username = "N/A";
                userTwo.tutorialLevel = false;
                userTwo.currency = 100;
                userTwo.maxSanity = 3;
                userTwo.SavePlayer();
                break;
            case 3:
                userThree.emptySlot = true;
                userThree.username = "N/A";
                userThree.tutorialLevel = false;
                userThree.currency = 100;
                userThree.maxSanity = 3;
                userThree.SavePlayer();
                break;
        }
    }

    private void LoadUsers()
    {
        if (userOne.emptySlot == false)
        {
            user1.interactable = false;
            user1Load.interactable = true;
            deleteBtn1.SetActive(true);
        }
        else
        {
            user1.interactable = true;
            user1Load.interactable = false;
            deleteBtn1.SetActive(false);
        }

        user1Name.text = userOne.username;
        user1NameLoad.text = userOne.username;

        if (userTwo.emptySlot == false)
        {
            user2.interactable = false;
            user2Load.interactable = true;
            deleteBtn2.SetActive(true);
        }
        else
        {
            user2.interactable = true;
            user2Load.interactable = false;
            deleteBtn2.SetActive(false);
        }

        user2Name.text = userTwo.username;
        user2NameLoad.text = userTwo.username;

        if (userThree.emptySlot == false)
        {
            user3.interactable = false;
            user3Load.interactable = true;
            deleteBtn3.SetActive(true);
        }
        else
        {
            user3.interactable = true;
            user3Load.interactable = false;
            deleteBtn3.SetActive(false);
        }

        user3Name.text = userThree.username;
        user3NameLoad.text = userThree.username;
    }

    public void newGame(int x)
    {
        string username;
        switch (x)
        {
            case 1:
                username = user1inp.text.ToString();
                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username) || username.Contains(" "))
                {
                    user1Dialogue.text = "Your name can't be empty or with spaces!";
                    wrongAnswer.Play();
                    StartCoroutine(resetDialogue());
                }
                else
                {
                    if (username.ToLower() == userTwo.username.ToLower() || username.ToLower() == userThree.username.ToLower())
                    {
                        user1Dialogue.text = "Your name can't be the same with the other users!";
                        wrongAnswer.Play();
                        StartCoroutine(resetDialogue());
                    }
                    else
                    {
                        currentTestSubjectID += 1;
                        userOne.testSubjectID = currentTestSubjectID;
                        userOne.emptySlot = false;
                        userOne.username = username;
                        userOne.currency = 0;
                        userOne.maxSanity = 3;
                        userLoaded = 1;
                        PlayerPrefs.SetInt("UserLoaded", userLoaded);
                        PlayerPrefs.SetInt("currentTestSubjectID", currentTestSubjectID);
                        userOne.SavePlayer();
                        level.LoadLevel(1);
                    }
                }
                break;
            case 2:
                username = user2inp.text.ToString();
                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username) || username.Contains(" "))
                {
                    user2Dialogue.text = "Your name can't be empty or with spaces!";
                    wrongAnswer.Play();
                    StartCoroutine(resetDialogue());
                }
                else
                {
                    if (username.ToLower() == userOne.username.ToLower() || username.ToLower() == userThree.username.ToLower())
                    {
                        user2Dialogue.text = "Your name can't be the same with the other users!";
                        wrongAnswer.Play();
                        StartCoroutine(resetDialogue());
                    }
                    else
                    {
                        currentTestSubjectID += 1;
                        userTwo.testSubjectID = currentTestSubjectID;
                        userTwo.emptySlot = false;
                        userTwo.username = username;
                        userTwo.currency = 0;
                        userTwo.maxSanity = 3;
                        userLoaded = 2;
                        PlayerPrefs.SetInt("UserLoaded", userLoaded);
                        PlayerPrefs.SetInt("currentTestSubjectID", currentTestSubjectID);
                        userTwo.SavePlayer();
                        level.LoadLevel(1);
                    }
                }
                break;
            case 3:
                username = user3inp.text.ToString();
                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username) || username.Contains(" "))
                {
                    user3Dialogue.text = "Your name can't be empty or with spaces!";
                    wrongAnswer.Play();
                    StartCoroutine(resetDialogue());
                }
                else
                {
                    if (username.ToLower() == userOne.username.ToLower() || username.ToLower() == userTwo.username.ToLower())
                    {
                        user3Dialogue.text = "Your name can't be the same with the other users!";
                        wrongAnswer.Play();
                        StartCoroutine(resetDialogue());
                    }
                    else
                    {
                        currentTestSubjectID += 1;
                        userThree.testSubjectID = currentTestSubjectID;
                        userThree.emptySlot = false;
                        userThree.username = username;
                        userThree.currency = 0;
                        userThree.maxSanity = 3;
                        userLoaded = 3;
                        PlayerPrefs.SetInt("UserLoaded", userLoaded);
                        PlayerPrefs.SetInt("currentTestSubjectID", currentTestSubjectID);
                        userThree.SavePlayer();
                        level.LoadLevel(1);
                    }
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
                    userLoaded = 1;
                    PlayerPrefs.SetInt("UserLoaded", userLoaded);
                    level.LoadLevel(1);
                }
                else
                {
                    userLoaded = 1;
                    PlayerPrefs.SetInt("UserLoaded", userLoaded);
                    level.LoadLevel(2);
                }
                break;

            case 2:
                if (userTwo.tutorialLevel == false)
                {
                    userLoaded = 2;
                    PlayerPrefs.SetInt("UserLoaded", userLoaded);
                    level.LoadLevel(1);
                }
                else
                {
                    userLoaded = 2;
                    PlayerPrefs.SetInt("UserLoaded", userLoaded);
                    level.LoadLevel(2);
                }
                break;

            case 3:
                if (userThree.tutorialLevel == false)
                {
                    userLoaded = 3;
                    PlayerPrefs.SetInt("UserLoaded", userLoaded);
                    level.LoadLevel(1);
                }
                else
                {
                    userLoaded = 3;
                    PlayerPrefs.SetInt("UserLoaded", userLoaded);
                    level.LoadLevel(2);
                }
                break;
        }
    }

    private IEnumerator resetDialogue()
    {
        yield return new WaitForSeconds(2f);

        user1Dialogue.text = "What is your name....?";
        user2Dialogue.text = "What is your name....?";
        user3Dialogue.text = "What is your name....?";
    }
}
