using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBoxScript : MonoBehaviour
{
    public Animator boxOB;
    public GameObject keyOBNeeded;
    public GameObject openText;
    public GameObject keyMissingText;
    public AudioSource openSound;
    public AudioSource lockedSound;
    public Button interactBtn;

    public bool inReach;
    public bool isOpen;
    public bool isInteracted;



    void Start()
    {
        isInteracted = false;
        inReach = false;
        openText.SetActive(false);
        keyMissingText.SetActive(false);
        interactBtn.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
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
        }

        else if (keyOBNeeded.activeInHierarchy == false && inReach && isInteracted)
        {
            openText.SetActive(false);
            keyMissingText.SetActive(true);
            lockedSound.Play();
        }

        if(isOpen)
        {
            boxOB.GetComponent<BoxCollider>().enabled = false;
            boxOB.GetComponent<OpenBoxScript>().enabled = false;
        }

        isInteracted = false;
    }
}
