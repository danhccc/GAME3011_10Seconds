using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private PlayerInput playerInput;
    private PlayerInputData playerInputData;
    public GameObject followTransform;
    public GameObject playerHelmet;
    public GameObject pauseMenu;

    [Header("Player Status")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJumpForce;
    [SerializeField] private float aimSensitivity;

    [Header("Player Actions")]
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isNearBy;
    [SerializeField] private bool isPause = false;

    //Movement Reference
    private Vector2 inputVector = Vector2.zero;
    private Vector3 moveDirection = Vector3.zero;
    private Vector2 lookInput = Vector2.zero;

    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");
    public readonly int isJumpingHash = Animator.StringToHash("isJumping");


    [SerializeField]
    private GameObject doortoOpen;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        doortoOpen = GameObject.Find("starter_door");
        
    }

    private void Update()
    {
        if (!TimerManager.Instance.AllowGameInput)
            return;

        // Camera X_Axis rotation
        followTransform.transform.rotation *= Quaternion.AngleAxis(lookInput.x * aimSensitivity, Vector3.up);
        followTransform.transform.rotation *= Quaternion.AngleAxis(lookInput.y * aimSensitivity, Vector3.left);
        // Camera Y_Axis rotation
        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTransform.transform.localEulerAngles.x;

        if (angle > 180 && angle < 300)
        {
            angles.x = 300;
        }
        else if (angle < 180 && angle > 70)
        {
            angles.x = 70;
        }

        followTransform.transform.localEulerAngles = angles;

        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0f, 0f);

        //
        // Movement
        //

        if (!(inputVector.magnitude > 0))
            moveDirection = Vector3.zero;

        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;

        Vector3 movementDirection = moveDirection * (playerSpeed * Time.deltaTime);

        transform.position += movementDirection;
    }

    public void OnMovement(InputValue value)
    {
        if (!TimerManager.Instance.AllowGameInput)
            return;

        inputVector = value.Get<Vector2>();
        animator.SetFloat(movementXHash, inputVector.x);
        animator.SetFloat(movementYHash, inputVector.y);
    }

    public void OnJump(InputValue value)
    {
        if (!TimerManager.Instance.AllowGameInput)
            return;

        if (isJumping)
            return;

        isJumping = true;
        rb.AddForce((transform.up /*+ moveDirection*/) * playerJumpForce, ForceMode.Impulse);
        animator.SetBool(isJumpingHash, isJumping);
    }

    public void OnLook(InputValue value)
    {
        if (!TimerManager.Instance.AllowGameInput)
            return;

        lookInput = value.Get<Vector2>();
        // If we aim up, down, adjust animations to have a mask that will let us properly animate aim

    }

    public void OnInteract(InputValue value)
    {
        if (!isNearBy) return;

        TimerManager.Instance.gameStarted = true;
        playerHelmet.SetActive(true);
        doortoOpen.GetComponent<StartingGateBehaviour>().PlayDoorOpenSoundClip();
    }

    public void OnPause(InputValue value)
    {
        TimerManager.Instance.Pause();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool(isJumpingHash, isJumping);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StartingGate"))
        {
            isNearBy = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("StartingGate"))
        {
            isNearBy = false;
        }
    }
}

