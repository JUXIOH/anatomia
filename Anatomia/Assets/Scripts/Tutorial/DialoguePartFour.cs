using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguePartFour : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public Button next;

    public GameObject hud;
    public GameObject texts;
    public GameObject tutorialCanvas;

    private int index = 0;
    private bool nextClick = false;
    private int currentUser;

    private PlayerOne user1;
    private PlayerTwo user2;
    private PlayerThree user3;
    private LevelLoader level;

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
            user1 = FindObjectOfType<PlayerOne>();
            user2 = FindObjectOfType<PlayerTwo>();
            user3 = FindObjectOfType<PlayerThree>();
            level = FindObjectOfType<LevelLoader>();

            currentUser = PlayerPrefs.GetInt("UserLoaded");
            next.interactable = false;
            switch (currentUser)
            {
                case 1:
                    user1.tutorialLevel = true;
                    user1.SavePlayer();
                    level.LoadLevel(2);
                    gameObject.SetActive(false);
                    break;
                case 2:
                    user2.tutorialLevel = true;
                    user2.SavePlayer();
                    level.LoadLevel(2);
                    gameObject.SetActive(false);
                    break;
                case 3:
                    user3.tutorialLevel = true;
                    user3.SavePlayer();
                    level.LoadLevel(2);
                    gameObject.SetActive(false);
                    break;
            }
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
