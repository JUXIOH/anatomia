using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int sanity = 10;
    public int maxSanity;

    public Image[] sanities;
    public Sprite filledSanity;
    public Sprite emptySanity;

    public GameObject deathscreen;

    private SelectedPlayer userSelected;

    private void Update()
    {
        userSelected = FindObjectOfType<SelectedPlayer>();
        userSelected.LoadPlayer();

        maxSanity = userSelected.maxSanity;

        if (sanity > maxSanity)
        {
            sanity = maxSanity;
        }

        for (int i = 0; i < sanities.Length; i++)
        {
            if(i < sanity)
            {
                sanities[i].sprite = filledSanity;
            } else
            {
                sanities[i].sprite = emptySanity;
            }

            if(i < maxSanity)
            {
                sanities[i].enabled = true;
            } else
            {
                sanities[i].enabled = false;
            }
        }
    }

    public void takeDamage()
    {
        sanity -= 1;

        if(sanity <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        deathscreen.SetActive(true);
    }
}
