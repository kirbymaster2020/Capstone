using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    
    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCooldown = 1.0f;

    private float dashCounter, dashCooldownCounter;

    void Start()
    {
        activeMoveSpeed = MoveSpeed;

            
    }


    // Update is called once per frame
    void Update()
    {
        //input goes here
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

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
            }

        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0 )
            {
                activeMoveSpeed = MoveSpeed;
                dashCooldownCounter = dashCooldown;
            }
        }

        if (dashCooldownCounter >  0)
        {
            dashCooldownCounter -= Time.deltaTime;
        }


    }

}
