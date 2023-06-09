using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doors : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public Button interactBtn;

    public AudioSource doorSound;


    public bool inReach;
    public bool isInteracted;

    void Start()
    {
        inReach = false;
        isInteracted = false;
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
        }
    }

    void Update()
    {
        if (inReach && isInteracted)
        {
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
        //Debug.Log("It Opens");
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
        doorSound.Play();

    }

    void DoorCloses()
    {
        //Debug.Log("It Closes");
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
    }


}
