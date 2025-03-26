using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5.0f;

    public Rigidbody2D rb;

    public Animator animator;

    [Header("Footstep Sound")]
    [SerializeField] private AudioClip footstepSound;
    [SerializeField] private float footstepCooldown = 0.3f;
    private AudioSource audioSource;
    private float footstepTimer;

    Vector2 movement;

    private Vector2 input;

    private Vector2 lastMoveDirection;

    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCooldown = 1.0f;

    private float dashCounter, dashCooldownCounter;

    void Start()
    {
        activeMoveSpeed = MoveSpeed;
        animator.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


    }


    // Update is called once per frame

    public float moveXAttack;
    public float moveYAttack;
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveXAttack = moveX;
        moveYAttack = moveY;

        if ((moveX == 0 && moveY == 0) && (input.x != 0 || input.y != 0))
        {
            lastMoveDirection = input;
        }


        //input goes here
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.sqrMagnitude > 0.01f && footstepTimer <= 0 && dashCounter <= 0)
        {
            audioSource.PlayOneShot(footstepSound);
            footstepTimer = footstepCooldown;
        }
        footstepTimer -= Time.deltaTime;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        animator.SetFloat("MoveX", input.x);
        animator.SetFloat("MoveY", input.y);
        animator.SetFloat("MoveMagnitude", input.magnitude);
        animator.SetFloat("LastMoveX", lastMoveDirection.x);
        animator.SetFloat("LastMoveY", lastMoveDirection.y);

    }

    void FixedUpdate()
    {
        //movement goes here
        rb.MovePosition(rb.position + movement * activeMoveSpeed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCooldownCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                Debug.Log("Dash On Cooldown...");

            }

        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = MoveSpeed;
                dashCooldownCounter = dashCooldown;
                Debug.Log("Dash Refreshed.");

            }
        }

        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.deltaTime;
        }


    }

}