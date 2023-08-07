using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpKey : MonoBehaviour
{
    public GameObject keyOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public GameObject keyNameText;
    public AudioSource keySound;
    public Button interactBtn;

    public bool inReach;
    public bool isInteracted = false;


    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        keyNameText.SetActive(false);
        invOB.SetActive(false);
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
            pickUpText.SetActive(true);
            keyNameText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
            keyNameText.SetActive(false);
        }
    }


    void Update()
    {
        if (inReach && isInteracted)
        {
            keyOB.SetActive(false);
            keySound.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);
            keyNameText.SetActive(false);
        }

        isInteracted = false;
    }
}
