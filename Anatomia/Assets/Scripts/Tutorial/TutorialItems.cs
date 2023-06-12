using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItems : MonoBehaviour
{
    public GameObject hud;
    public GameObject tutorialCanvas;
    public GameObject box;

    public GameObject[] tutPanels;

    private CharacterControl playerCharacter;

    int tutIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartTutorial();

            playerCharacter = other.GetComponent<CharacterControl>();
            if(playerCharacter != null)
            {
                playerCharacter.SetCanMove(false);
            }
        }
    }

    void StartTutorial()
    {
        hud.SetActive(false);
        tutorialCanvas.SetActive(true);
    }

    public void tutorialClick()
    {
        Debug.Log("Clicked");
        switch (tutIndex)
        {
            case 0:
                tutPanels[tutIndex].SetActive(false);
                tutIndex++;
                tutPanels[tutIndex].SetActive(true);
                break;
            case 1:
                tutPanels[tutIndex].SetActive(false);
                tutIndex++;
                tutPanels[tutIndex].SetActive(true);
                break;
            case 2:
                StartGame();
                break;
        }
    }

    void StartGame()
    {
        tutorialCanvas.SetActive(false);
        box.SetActive(false);
        hud.SetActive(true);

        if(playerCharacter != null)
        {
            playerCharacter.SetCanMove(true);
        }
    }


}
