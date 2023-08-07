using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour
{

    public Animator door;
    public GameObject lockOB;
    public GameObject keyOB;
    public GameObject openText;
    public GameObject closeText;
    public GameObject lockedText;
    public GameObject tutorialCanvas;
    public GameObject dialogueTwo;

    public Button interactBtn;


    public AudioSource openSound;
    public AudioSource closeSound;
    public AudioSource lockedSound;
    public AudioSource unlockedSound;

    private bool inReach;
    private bool doorisOpen;
    private bool doorisClosed;
    public bool locked;
    public bool unlocked;
    public bool isInteracted;
    public bool hasBeenOpenedOnce = false;

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
            lockedText.SetActive(false);
            closeText.SetActive(false);
        }
    }

    void Start()
    {
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
        if (lockOB.activeInHierarchy)
        {
            locked = true;
            unlocked = false;
        }

        else
        {
            unlocked = true;
            locked = false;
        }

        if (inReach && keyOB.activeInHierarchy && isInteracted)
        {
            unlockedSound.Play();
            locked = false;
            keyOB.SetActive(false);
            StartCoroutine(unlockDoor());
        }

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

        if (inReach && locked && isInteracted)
        {
            openText.SetActive(false);
            lockedText.SetActive(true);
            lockedSound.Play();

            if(hasBeenOpenedOnce == false)
            {
                hasBeenOpenedOnce = true;
                StartCoroutine(waitASec());
            }
        }

        isInteracted = false;
    }

    IEnumerator waitASec()
    {
        yield return new WaitForSeconds(1f);
        {
            tutorialCanvas.SetActive(true);
            dialogueTwo.SetActive(true);
        }
    }

    IEnumerator unlockDoor()
    {
        yield return new WaitForSeconds(.05f);
        {
            unlocked = true;
            lockOB.SetActive(false);
        }
    }




}
