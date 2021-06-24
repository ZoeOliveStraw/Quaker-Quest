using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plyrJump : MonoBehaviour
{
    Rigidbody rb;
    InputManager controls;
    private bool isGrounded = false;
    [SerializeField] float jumpForce;
    [SerializeField] float flapForce;
    [SerializeField] float decayThreshold;
    [SerializeField] float decayAmount;
    [SerializeField] float maxYSpeed;
    private float updatedYSpeed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform[] groundCheck;
    [SerializeField] Slider staminaBar;
    [SerializeField] float maxStamina;
    [SerializeField] float flapStamina;
    [SerializeField] float staminaRegenPerFrame;
    private float currentStamina;
    private Vector3 downVector;
    private Vector3 upVector;

    private Animator animator;
    private Vector2 moveVector;
    private plyrSounds sounds;
    

    void Awake()
    {
        controls = new InputManager();
        controls.Player.Jump.performed += _ => Jump();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sounds = GetComponent<plyrSounds>();
        downVector = Vector3.down;
        upVector = Vector3.up;
        currentStamina = maxStamina;
        RenderStamina();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundCheck();
        Gravity();
        StaminaRegen();
    }

    void Update()
    {
        Animation();
    }

    void Gravity()
    {
        updatedYSpeed = rb.velocity.y;
        if(Mathf.Abs(rb.velocity.y) > decayThreshold)
        {
            updatedYSpeed -= decayAmount;
        }
        updatedYSpeed = Mathf.Clamp(updatedYSpeed, -maxYSpeed,maxYSpeed);
        rb.velocity = new Vector3(rb.velocity.x,updatedYSpeed,rb.velocity.z);
    }

    void GroundCheck()
    {
        foreach(Transform g in groundCheck)
        {
            if(Physics.Raycast(g.position,downVector,0.2f,groundLayer))
            {
                isGrounded = true;
                break;
            }
            else
            {
                isGrounded = false;
            }
        }
    }

    void Jump()
    {
        if(isGrounded)
        {
            rb.AddForce(upVector * jumpForce);
            animator.Play("Angus_Flap");
            sounds.JumpSound();
        }
        else
        {
            Flap();
        }
        
    }

    void Flap()
    {
        if(currentStamina > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y * 0.3f,rb.velocity.z);
            rb.AddForce(upVector * flapForce);
            animator.Play("Angus_Flap");
            currentStamina -= flapStamina;
            RenderStamina();
        }
    }

    private void Animation()
    {
        if(isGrounded)
        {
            moveVector = controls.Player.Movement.ReadValue<Vector2>();
            if(moveVector.magnitude > 0.1f)
            {
                animator.Play("Angus_Walk");
            }
            else
            {
                animator.Play("Angus_Idle");
            }
        }
    }

    private void RenderStamina()
    {
        if(currentStamina >= maxStamina)
        {
            staminaBar.gameObject.SetActive(false);
        }
        else
        {
            staminaBar.gameObject.SetActive(true);
            staminaBar.minValue = 0;
            staminaBar.maxValue = maxStamina;
            staminaBar.value = currentStamina;
        }
        
    }

    private void StaminaRegen()
    {
        if(isGrounded)
        {
            currentStamina += staminaRegenPerFrame;
            if(currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
            RenderStamina();
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
