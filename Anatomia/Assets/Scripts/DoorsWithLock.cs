using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorsWithLock : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject KeyINV;

    public Button interactBtn;

    public AudioSource doorSound;
    public AudioSource lockedSound;


    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;
    public bool isInteracted;


    void Start()
    {
        inReach = false;
        hasKey = false;
        unlocked = false;
        locked = true;
        interactBtn.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        isInteracted = true;

        if (locked && inReach && isInteracted)
        {
            lockedSound.Play();

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }





    void Update()
    {
        if(KeyINV.activeInHierarchy)
        {
            locked = false;
            hasKey = true;
        }  
        else
        {
            hasKey = false;
        }

        if (hasKey && inReach && isInteracted)
        {
            unlocked = true;
            DoorOpens();
        }
        else
        {
            DoorCloses();
        }

        isInteracted = false;
    }
    void DoorOpens ()
    {
        if (unlocked)
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            doorSound.Play();
        }

    }

    void DoorCloses()
    {
        if (unlocked)
        {
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
        }

    }


}
