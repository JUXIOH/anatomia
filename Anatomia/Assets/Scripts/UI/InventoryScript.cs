using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject inGameHUD;
    public GameObject inventoryHUD;
    public GameObject textsHUD;
    public GameObject image;
    public GameObject text;

    public GameObject[] keyOb;
    public GameObject[] buttons;

    private int x = 0;

    public void CheckInventory()
    {
        textsHUD.SetActive(false);
        inGameHUD.SetActive(false);
        inventoryHUD.SetActive(true);

        foreach (GameObject obj in keyOb)
        {
            if (obj.activeInHierarchy)
            {
                buttons[x].SetActive(true);
            }
            else
            {
                buttons[x].SetActive(false);
            }

            x++;
        }

        x = 0;
    }

    public void ExitInventory()
    {
        textsHUD.SetActive(true);
        inGameHUD.SetActive(true);
        inventoryHUD.SetActive(false);
        image.SetActive(false);
        text.SetActive(false);
    }
}
