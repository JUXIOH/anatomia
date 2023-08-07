using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float walkingSpeed = 5f;
    public float runningSpeed = 10f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public AudioSource footstepsWalk;
    public AudioSource footstepsRun;

    public GameObject userOne;
    public GameObject userTwo;
    public GameObject userThree;

    private PlayerOne user1;
    private PlayerTwo user2;
    private PlayerThree user3;
    private SelectedPlayer userSelected;

    private int CurrentUserSlot;

    [HideInInspector]
    public Vector2 RunAxis;
    [HideInInspector]
    public Vector2 LookAxis;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;
    [HideInInspector]
    public bool isRunning = false;

    [HideInInspector] public StaminaController _staminaController;

    private int ID;
    private string Name;


    void Start()
    {
        _staminaController = GetComponent<StaminaController>();
        characterController = GetComponent<CharacterController>();
    }

    private void Awake()
    {
        CurrentUserSlot = PlayerPrefs.GetInt("UserLoaded");
        checkUser();
    }

    void checkUser()
    {
        switch (CurrentUserSlot)
        {
            case 1:
                userOne.SetActive(true);
                break;
            case 2:
                userTwo.SetActive(true);
                break;
            case 3:
                userThree.SetActive(true);
                break;
        }
    }

    public void SetRunSpeed(float Speed)
    {
        runningSpeed = Speed;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    public void OnButtonPressed()
    {
        isRunning = true;
    }

    public void OnButtonReleased()
    {
        isRunning = false;
        _staminaController.isSprinting = false;
    }

    void Update()
    {
        if (isRunning == true && JoyStick.isMoving == true)
        {
            footstepsRun.enabled = true;
            footstepsWalk.enabled = false;
        }
        else if (isRunning == false && JoyStick.isMoving == true)
        {
            footstepsWalk.enabled = true;
            footstepsRun.enabled = false;
        }
        else
        {
            footstepsWalk.enabled = false;
            footstepsRun.enabled = false;
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        //bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * RunAxis.y : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * RunAxis.x : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        moveDirection.y = movementDirectionY;

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (isRunning && characterController.velocity.sqrMagnitude > 0)
        {
            if (_staminaController.playerStamina > 0)
            {
                _staminaController.isSprinting = true;
                _staminaController.Sprinting();
            }
            else
            {
                isRunning = false;
            }
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -LookAxis.y * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, LookAxis.x * lookSpeed, 0);
        }
    }
}

