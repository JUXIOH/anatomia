using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonScript : MonoBehaviour
{
    public Image imageToChange;
    public Sprite changeImage;
    public TMPro.TMP_Text textToChange;

    public GameObject image;
    public GameObject text;

    public void OnClick(string s)
    {
        imageToChange.sprite = changeImage;
        textToChange.SetText(s);

        image.SetActive(true);
        text.SetActive(true);
    }
}
