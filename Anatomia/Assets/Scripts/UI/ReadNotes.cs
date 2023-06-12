using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReadNotes : MonoBehaviour
{
    public GameObject noteUI;
    public GameObject hud;
    public GameObject inv;

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
            pickUpSound.Play();
            hud.SetActive(false);
            inv.SetActive(false);
        }

        isInteracted = false;
    }


    public void ExitButton()
    {

        noteUI.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);

    }
}
