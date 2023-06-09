using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;

    public Button flashlightBtn;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;

    public bool flashPressed;



    void Start()
    {
        off = true;
        flashlight.SetActive(false);
        flashlightBtn.onClick.AddListener(OnButtonPressed);
    }

    void OnButtonPressed()
    {
        if (flashPressed)
        {
            flashPressed = false;
        }
        else
        {
            flashPressed = true;
        }
    }


    void Update()
    {
        if(off && flashPressed)
        {
            flashlight.SetActive(true);
            turnOn.Play();
            off = false;
            on = true;
        }
        else if (on && !flashPressed)
        {
            flashlight.SetActive(false);
            turnOff.Play();
            off = true;
            on = false;
        }



    }
}
