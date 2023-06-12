using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCutscene : MonoBehaviour
{
    public GameObject tutorialCanvas;
    public GameObject joystick;
    public GameObject touchscreen;
    public GameObject interact;
    public GameObject flashlight;
    public GameObject sprint;
    public GameObject sanity;
    public GameObject inventory;
    public GameObject menu;
    public GameObject objective;
    public GameObject[] tutPanels;

    int tutIndex = 0;

    public void tutorialClick()
    {
        Debug.Log("Clicked");
        switch (tutIndex)
        {
            case 0:
                tutPanels[tutIndex].SetActive(false);
                tutIndex++;
                joystick.SetActive(true);
                tutPanels[tutIndex].SetActive(true);
                break;
            case 1:
                tutPanels[tutIndex].SetActive(false);
                joystick.SetActive(false);
                tutIndex++;
                tutPanels[tutIndex].SetActive(true);
                break;
            case 2:
                tutPanels[tutIndex].SetActive(false);
                tutIndex++;
                interact.SetActive(true);
                tutPanels[tutIndex].SetActive(true);
                break;
            case 3:
                interact.SetActive(false);
                tutPanels[tutIndex].SetActive(false);
                tutIndex++;
                flashlight.SetActive(true);
                tutPanels[tutIndex].SetActive(true);
                break;
            case 4:
                flashlight.SetActive(false);
                tutPanels[tutIndex].SetActive(false);
                tutIndex++;
                sprint.SetActive(true);
                tutPanels[tutIndex].SetActive(true);
                break;
            case 5:
                sprint.SetActive(false);
                tutPanels[tutIndex].SetActive(false);
                tutIndex++;
                sanity.SetActive(true);
                tutPanels[tutIndex].SetActive(true);
                break;
            case 6:
                sanity.SetActive(false);
                tutPanels[tutIndex].SetActive(false);
                tutIndex++;
                inventory.SetActive(true);
                tutPanels[tutIndex].SetActive(true);
                break;
            case 7:
                inventory.SetActive(false);
                tutPanels[tutIndex].SetActive(false);
                tutIndex++;
                menu.SetActive(true);
                tutPanels[tutIndex].SetActive(true);
                break;
            case 8:
                menu.SetActive(false);
                tutPanels[tutIndex].SetActive(false);
                tutIndex++;
                tutPanels[tutIndex].SetActive(true);
                break;
            case 9:
                StartGame();
                break;
        }
    }

    void StartGame()
    {
        tutorialCanvas.SetActive(false);
        joystick.SetActive(true);
        touchscreen.SetActive(true);
        interact.SetActive(true);
        flashlight.SetActive(true);
        sprint.SetActive(true);
        sanity.SetActive(true);
        inventory.SetActive(true);
        menu.SetActive(true);
        objective.SetActive(true);
    }
}
