using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    public GameObject tutorialCanvas;
    public GameObject dialogueFour;

    void OnTriggerEnter(Collider other)
    {
        tutorialCanvas.SetActive(true);
        dialogueFour.SetActive(true);
    }
}
