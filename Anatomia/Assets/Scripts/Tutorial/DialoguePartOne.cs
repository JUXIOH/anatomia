using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialoguePartOne : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public Button next;

    public GameObject dialogBox;
    public GameObject nextBtn;

    public GameObject touchfieldColor;

    public GameObject joyStick;
    public GameObject touchfield;
    public GameObject interactBtn;
    public GameObject flashlightBtn;
    public GameObject menuBtn;
    public GameObject invBtn;
    public GameObject minimap;
    public GameObject sprintBtn;
    public GameObject sanityPoints;
    public GameObject objectives;
    public GameObject crosshair;

    private SelectedPlayer userSelected;

    private int index = 0;
    private bool nextClick = false;

    void Start()
    {
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

        switch (index)
        {
            case 10:
                dialogBox.SetActive(false);
                joyStick.SetActive(true);
                break;
            case 11:
                dialogBox.SetActive(true);
                joyStick.SetActive(false);
                break;
            case 12:
                dialogBox.SetActive(false);
                touchfield.SetActive(true);
                break;
            case 13:
                dialogBox.SetActive(true);
                touchfield.SetActive(false);
                break;
            case 14:
                dialogBox.SetActive(false);
                interactBtn.SetActive(true);
                break;
            case 15:
                dialogBox.SetActive(true);
                interactBtn.SetActive(false);
                break;
            case 16:
                dialogBox.SetActive(false);
                flashlightBtn.SetActive(true);
                break;
            case 17:
                dialogBox.SetActive(true);
                flashlightBtn.SetActive(false);
                break;
            case 18:
                dialogBox.SetActive(false);
                menuBtn.SetActive(true);
                break;
            case 19:
                dialogBox.SetActive(true);
                menuBtn.SetActive(false);
                break;
            case 20:
                dialogBox.SetActive(false);
                invBtn.SetActive(true);
                break;
            case 21:
                dialogBox.SetActive(true);
                invBtn.SetActive(false);
                break;
            case 22:
                dialogBox.SetActive(false);
                minimap.SetActive(true);
                break;
            case 23:
                dialogBox.SetActive(true);
                minimap.SetActive(false);
                break;
            case 24:
                dialogBox.SetActive(false);
                sprintBtn.SetActive(true);
                break;
            case 25:
                dialogBox.SetActive(true);
                sprintBtn.SetActive(false);
                break;
            case 26:
                dialogBox.SetActive(false);
                sanityPoints.SetActive(true);
                break;
            case 27:
                dialogBox.SetActive(true);
                sanityPoints.SetActive(false);
                break;
            case 28:
                dialogBox.SetActive(false);
                objectives.SetActive(true);
                break;
            case 29:
                dialogBox.SetActive(true);
                objectives.SetActive(false);
                break;
            default:
                break;
        }
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
            joyStick.SetActive(true);
            touchfield.SetActive(true);
            interactBtn.SetActive(true);
            flashlightBtn.SetActive(true);
            menuBtn.SetActive(true);
            invBtn.SetActive(true);
            minimap.SetActive(true);
            objectives.SetActive(true);
            sprintBtn.SetActive(true);
            sanityPoints.SetActive(true);
            crosshair.SetActive(true);
            touchfieldColor.SetActive(false);
            nextBtn.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        userSelected = FindObjectOfType<SelectedPlayer>();
        userSelected.LoadPlayer();

        switch (index)
        {
            case 1:
                lines[index] += userSelected.username + ".";
                break;
            case 5:
                lines[index] += userSelected.testSubjectID.ToString() + ".";
                break;
            case 6:
                lines[index] += userSelected.testSubjectID.ToString() + ".";
                break;
        }

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
