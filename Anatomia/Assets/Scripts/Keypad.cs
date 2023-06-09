using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject hud;
    public GameObject inv;
    public GameObject keypadKey;


    public GameObject animateOB;
    public Animator ANI;


    public Text textOB;
    public string answer = "12345";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    public Collider keypadCollider;

    public AdvancedDoorsKeypad door;

    void Start()
    {
        keypadOB.SetActive(false);
    }


    public void Number(int number)
    {
        textOB.text += number.ToString();
        button.Play();
    }

    public void Execute()
    {
        if (textOB.text == answer)
        {
            correct.Play();
            textOB.text = "Right";
        }
        else
        {
            wrong.Play();
            textOB.text = "Wrong";
            StartCoroutine(clearIE());
        }


    }

    public void Clear()
    {
        {
            textOB.text = "";
            button.Play();
        }
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
    }

    public void Update()
    {
        if (textOB.text == "Right")
        {
            door.locked = false;
            door.unlocked = true;
            door.openSound.Play();
            Debug.Log("its open");
            keypadKey.SetActive(true);
            StartCoroutine(clearIE());
        }

        if(keypadOB.activeInHierarchy)
        {
            hud.SetActive(false);
            inv.SetActive(false);
        }

    }

    IEnumerator clearIE()
    {
        yield return new WaitForSeconds(.5f);

        if(textOB.text == "Right")
        {
            Exit();
        }
        else
        {
            Clear();
        }
    }


}
