using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int sanity;
    public int maxSanity;

    public Image[] sanities;
    public Sprite filledSanity;
    public Sprite emptySanity;

    private void Update()
    {
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
}
