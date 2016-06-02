using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MovementScript : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 4f)]
    float MovingTurnSpeed = 360;
    [SerializeField]
    float JumpPower = 12f;
    [SerializeField]
    float GravityMultiplier = 2f;
    [SerializeField]
    float RunCycleLegOffset = 0.3f;
    [SerializeField]
    float MoveSpeedMultiplier = 1f;
    [SerializeField]
    float AnimSpeedMultiplier = 1f;
    [SerializeField]
    float GroundCheckDistance = 0.1f;
    [SerializeField]
    Transform resetPoint;
    [SerializeField]
    private LayerMask m_WhatIsGround;               // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private Vector3 c_Move;
    private bool c_Jump;
    private bool c_Run;
    private Animator c_Animator;
    private Rigidbody2D c_Rigidbody;
    private bool isGrounded;
    float c_OrigGroundCheckDistance;
    const float k_Half = 0.5f;
    float c_TurnAmount;
    Vector3 c_GroundNormal;
    bool doubleJump;
    bool damageTaken;
    bool right;


    void Start()
    {
        m_GroundCheck = transform.Find("GroundCheck");
        c_Rigidbody = GetComponent<Rigidbody2D>();
        c_Animator = GetComponent<Animator>();
        doubleJump = false;
    }

    void Update()
    {
        if (!c_Jump)
        {
            c_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        c_Animator = GetComponent<Animator>();
        checkForReset();
        c_Run = false;
        float h = CrossPlatformInputManager.GetAxis("Horizontal");

        if(h != 0)
        {
            c_Run = true;
        }

        c_Move = Vector3.right * h * 0.1f;


        // If running then increases the movement speed and the running animation
        if (CrossPlatformInputManager.GetButton("Run"))
        {
            MoveSpeedMultiplier = 1f;
            //AnimSpeedMultiplier = 1.25f;
        }
        else
        {
            MoveSpeedMultiplier = 2f;
            //AnimSpeedMultiplier = 1.0f;
        }


        Move();
        c_Jump = false;
    }

    //Moves the Character
    public void Move()
    {
        if (c_Move.magnitude > 1f)
        {
            c_Move.Normalize();
        }
        CheckGroundStatus();

        if (isGrounded)
        {
            HandleGroundedMovement();
        }
        else
        {
            HandleAirborneMovement();
        }

        c_Rigidbody.position = transform.position + (c_Move * MoveSpeedMultiplier);
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        c_Animator.SetBool("Run", c_Run);
        if (!c_Jump)
        {
            c_Animator.SetBool("Jump", false);
        }
        else
        {
           c_Animator.SetBool("Jump", true);
        }
    }

    void HandleAirborneMovement()
    {
        Vector3 extraGravityForce = (Physics.gravity * GravityMultiplier) - Physics.gravity;
        c_Rigidbody.AddForce(extraGravityForce);
        if(!doubleJump && c_Jump)
        {
            doubleJump = true;
            Jump();
        }

        //GroundCheckDistance = c_Rigidbody.velocity.y < 0 ? c_OrigGroundCheckDistance : 0.01f;
    }

    void HandleGroundedMovement()
    {
        //&& c_Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded")
        if (c_Jump)
        {
            Jump();
        }
    }

    void Jump()
    {
        c_Rigidbody.velocity = new Vector2(c_Rigidbody.velocity.x, JumpPower);
        isGrounded = false;
    }

    //public void OnAnimatorMove()
    //{
    //    if (isGrounded && Time.deltaTime > 0)
    //    {
    //        Vector3 v = (c_Animator.deltaPosition * MoveSpeedMultiplier) / Time.deltaTime;
    //        v.y = c_Rigidbody.velocity.y;
    //        c_Rigidbody.velocity = v;
    //    }
    //}

    void CheckGroundStatus()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                doubleJump = false;
            }
                
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.transform.position.y < transform.position.y-1)
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "CheckPoint")
        {
            resetPoint = other.transform;
        }
    }

    void checkForReset()
    {
        if(transform.position.y < -25)
        {
            transform.position = resetPoint.position;
            GetComponent<PlayerHealthScript>().TakeDamage(10);

        }
    }
}
