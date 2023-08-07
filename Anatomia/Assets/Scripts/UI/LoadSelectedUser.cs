using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSelectedUser : MonoBehaviour
{
    public GameObject userOne;
    public GameObject userTwo;
    public GameObject userThree;

    private SelectedPlayer userSelected;

    private PlayerOne user1;
    private PlayerTwo user2;
    private PlayerThree user3;

    private void Awake()
    {
        user1 = new PlayerOne();
        user2 = new PlayerTwo();
        user3 = new PlayerThree();

        userSelected = GetComponent<SelectedPlayer>();
    }

    void Update()
    {
        if (userOne.activeInHierarchy == true)
        {
            user1.LoadPlayer();
            userSelected.testSubjectID = user1.testSubjectID;
            userSelected.username = user1.username;
            userSelected.currency = user1.currency;
            userSelected.maxSanity = user1.maxSanity;
            userSelected.SavePlayer();
        }

        if (userTwo.activeInHierarchy == true)
        {
            user2.LoadPlayer();
            userSelected.testSubjectID = user2.testSubjectID;
            userSelected.username = user2.username;
            userSelected.currency = user2.currency;
            userSelected.maxSanity = user2.maxSanity;
            userSelected.SavePlayer();
        }

        if (userThree.activeInHierarchy == true)
        {
            user3.LoadPlayer();
            userSelected.testSubjectID = user3.testSubjectID;
            userSelected.username = user3.username;
            userSelected.currency = user3.currency;
            userSelected.maxSanity = user3.maxSanity;
            userSelected.SavePlayer();
        }
    }
}
