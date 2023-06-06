using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogue : MonoBehaviour
{
    public TMPro.TMP_Text dialogueText;
    public Button nextBtn;
    public GameObject disableDialogueScreen;
    public GameObject enableGamePlay;
    public GameObject enableSounds;
    public FirstPersonController scriptToEnable;

    public string[] firstbatchDialogues;
    private int currentDialogueIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        firstbatchDialogues = new string[]
        {
            "Hello there!"
        };

        nextBtn.onClick.AddListener(NextDialogue);
        StartDialogue();
    }

    private void StartDialogue()
    {
        dialogueText.text = firstbatchDialogues[currentDialogueIndex];
    }

    private void NextDialogue()
    {
        currentDialogueIndex++;

        if(currentDialogueIndex < firstbatchDialogues.Length)
        {
            dialogueText.text = firstbatchDialogues[currentDialogueIndex];
        }
        else
        {
            disableDialogueScreen.SetActive(false);
            enableGamePlay.SetActive(true);
            enableSounds.SetActive(true);
            scriptToEnable.enabled = true;
            Debug.Log("Dialog Ended!");
        }
    }
}
