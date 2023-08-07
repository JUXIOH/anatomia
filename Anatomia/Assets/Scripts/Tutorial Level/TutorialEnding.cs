using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnding : MonoBehaviour
{
    private PlayerOne user1;
    private LevelLoader level;

    public GameObject tutCanvas;
    public GameObject hud;

    private CharacterControl playerCharacter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hud.SetActive(false);
            tutCanvas.SetActive(true);

            playerCharacter = other.GetComponent<CharacterControl>();
            if (playerCharacter != null)
            {
                playerCharacter.SetCanMove(false);
            }
        }
    }

    private void Start()
    {
        user1 = FindObjectOfType<PlayerOne>();
        level = FindObjectOfType<LevelLoader>();
    }

    public void endTutorial()
    {
        tutCanvas.SetActive(false);
        user1.tutorialLevel = true;
        user1.SavePlayer();
        level.LoadLevel(0);
    }
}
