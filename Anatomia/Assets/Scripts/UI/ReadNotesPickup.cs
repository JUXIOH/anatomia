using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReadNotesPickup : MonoBehaviour
{
    public GameObject note;
    public GameObject noteUI;
    public GameObject hud;
    public GameObject inv;
    public GameObject invKeyOb;

    public Button interactBtn;

    public GameObject pickUpText;

    public AudioSource pickUpSound;

    public bool inReach;
    public bool isInteracted;



    void Start()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
        pickUpText.SetActive(false);

        inReach = false;
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

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }




    void Update()
    {
        if(isInteracted && inReach)
        {
            noteUI.SetActive(true);
            invKeyOb.SetActive(true);
            pickUpSound.Play();
            hud.SetActive(false);
            inv.SetActive(false);
        }

        isInteracted = false;
    }


    public void ExitButton()
    {

        isInteracted = false;
        inReach = false;
        pickUpText.SetActive(false);
        noteUI.SetActive(false);
        note.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);

    }
}
