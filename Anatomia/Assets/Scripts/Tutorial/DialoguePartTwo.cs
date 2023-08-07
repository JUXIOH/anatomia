using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguePartTwo : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public Button next;

    public TextMeshProUGUI objectiveChange;

    public GameObject hud;
    public GameObject texts;
    public GameObject tutorialCanvas;

    private int index = 0;
    private bool nextClick = false;

    private CharacterControl player;
    private MobileInput input;

    void Start()
    {
        player = FindObjectOfType<CharacterControl>();
        input = FindObjectOfType<MobileInput>();

        player.enabled = false;
        input.enabled = false;
        hud.SetActive(false);
        texts.SetActive(false);
        textComponent.text = string.Empty;

        StartDialogue();

        next.onClick.AddListener(Next);
    }

    void Next()
    {
        nextClick = true;
    }

    void Update()
    {
        if (nextClick == true)
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        nextClick = false;
    }

    void StartDialogue()
    {
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {

        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            objectiveChange.text = "Objectives: \n1. Exit the building. \n2. Get the key inside the storage room. \n3. Find the piece of paper containing the code. (Optional)";
            hud.SetActive(true);
            texts.SetActive(true);
            tutorialCanvas.SetActive(false);
            player.enabled = true;
            input.enabled = true;
            gameObject.SetActive(false);
            next.interactable = false;
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
