using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("Main Parameters for Stamina")]
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool isSprinting = false;

    [Header("Stamina Regen Parameters")]
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

    [Header("Stamina Speed Parameters")]
    [SerializeField] private int slowedRunSpeed = 4;
    [SerializeField] private int normalRunSpeed = 8;

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgessUI;
    [SerializeField] private CanvasGroup sliderCanvasGroup;

    public GameObject sprintBtn;
    public GameObject tiredBtn;

    private CharacterControl playerController;

    private void Start()
    {
        playerController = GetComponent<CharacterControl>();
    }

    private void Update()
    {
        if (!isSprinting)
        {
            if (playerStamina <= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStamina(1);

                if (playerStamina >= maxStamina)
                {
                    playerController.SetRunSpeed(normalRunSpeed);
                    sliderCanvasGroup.alpha = 0;
                    hasRegenerated = true;
                    sprintBtn.SetActive(true);
                    tiredBtn.SetActive(false);
                }
            }
        }
    }

    public void Sprinting()
    {
        if (hasRegenerated)
        {
            isSprinting = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);

            if (playerStamina <= 0)
            {
                hasRegenerated = false;
                playerController.SetRunSpeed(slowedRunSpeed);
                sliderCanvasGroup.alpha = 0;
                sprintBtn.SetActive(false);
                playerController.OnButtonReleased();
                tiredBtn.SetActive(true);
            }
        }
    }

    void UpdateStamina(int value)
    {
        staminaProgessUI.fillAmount = playerStamina / maxStamina;

        if (value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }
}
