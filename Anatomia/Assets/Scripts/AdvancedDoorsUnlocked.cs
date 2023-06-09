using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedDoorsUnlocked : MonoBehaviour
{

    public Animator door;
    public GameObject openText;
    public GameObject closeText;

    public Button interactBtn;


    public AudioSource openSound;
    public AudioSource closeSound;

    private bool inReach;
    private bool doorisOpen;
    private bool doorisClosed;
    public bool unlocked;
    public bool isInteracted;





    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && doorisClosed)
        {
            inReach = true;
            openText.SetActive(true);
        }

        if (other.gameObject.tag == "Reach" && doorisOpen)
        {
            inReach = true;
            closeText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            closeText.SetActive(false);
        }
    }

    void Start()
    {
        unlocked = true;
        isInteracted = false;
        inReach = false;
        doorisClosed = true;
        doorisOpen = false;
        closeText.SetActive(false);
        openText.SetActive(false);
        interactBtn.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        isInteracted = true;
    }

    void Update()
    {

        if (inReach && doorisClosed && unlocked && isInteracted)
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            openText.SetActive(false);
            openSound.Play();
            doorisOpen = true;
            doorisClosed = false;
        }

        else if (inReach && doorisOpen && unlocked && isInteracted)
        {
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
            closeText.SetActive(false);
            closeSound.Play();
            doorisClosed = true;
            doorisOpen = false;
        }

        isInteracted = false;
    }




}
