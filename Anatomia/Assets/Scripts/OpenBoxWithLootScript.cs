using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBoxWithLootScript : MonoBehaviour
{
    public Animator boxOB;
    public GameObject keyOBNeeded;
    public GameObject openText;
    public GameObject keyMissingText;
    public AudioSource openSound;
    public AudioSource lockedSound;

    public Button interactBtn;

    public GameObject[] drop;

    public bool inReach;
    public bool isOpen;
    public bool isInteracted;

    public int randomNumber;



    void Start()
    {
        randomNumber = Random.Range(0, drop.Length);
        inReach = false;
        isInteracted = false;
        openText.SetActive(false);
        keyMissingText.SetActive(false);
        interactBtn.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        isInteracted = true;
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
            keyMissingText.SetActive(false);
        }
    }


    void Update()
    {
        if (keyOBNeeded.activeInHierarchy == true && inReach && isInteracted)
        {
            keyOBNeeded.SetActive(false);
            openSound.Play();
            boxOB.SetBool("open", true);
            openText.SetActive(false);
            keyMissingText.SetActive(false);
            isOpen = true;

            drop[randomNumber].SetActive(true);
        }

        else if (keyOBNeeded.activeInHierarchy == false && inReach && isInteracted)
        {
            lockedSound.Play();
            openText.SetActive(false);
            keyMissingText.SetActive(true);
        }

        if(isOpen)
        {
            boxOB.GetComponent<BoxCollider>().enabled = false;
            boxOB.GetComponent<OpenBoxWithLootScript>().enabled = false;
        }

        isInteracted = false;
    }
}
