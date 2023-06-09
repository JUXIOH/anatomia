using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenKeyPad : MonoBehaviour
{
    public GameObject keypadOB;
    public GameObject keypadText;

    public Button interactBtn;

    public bool inReach;
    public bool isInteracted;


    void Start()
    {
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
            keypadText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            keypadText.SetActive(false);

        }
    }




    void Update()
    {
        if(isInteracted && inReach)
        {
            keypadOB.SetActive(true);
        }

        isInteracted = false;
    }
}
