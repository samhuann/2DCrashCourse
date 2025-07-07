using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float walkSpeed = 5f;

    Vector2 moveInput;

    [SerializeField]
    private bool _isMoving = false;
    public bool isMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.IsMoving, value);
        }
    }
    [SerializeField]

    private bool _isRunning = false;


    public bool isRunning
    {
        get
        {
            return _isRunning;
        }
        private set
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.IsRunning, value);
        }
    }

    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * walkSpeed, rb.linearVelocity.y);

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        isMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput.x);
        
    }

    private void SetFacingDirection(float x)
    {
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }

    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isRunning = true;
            walkSpeed *= 2; // Double the speed when running
        }
        else if (context.canceled)
        {
            isRunning = false;
            walkSpeed /= 2; // Reset to normal speed when not running
        }
    }
}
