using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MovementScript : MonoBehaviour
{
    [SerializeField]
    float MovingTurnSpeed = 360;
    [SerializeField]
    float StationaryTurnSpeed = 180;
    [SerializeField]
    float JumpPower = 12f;
    [Range(1f, 4f)]
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


    private Vector3 c_Move;
    private bool c_Jump;
    //private Animator c_Animator;
    private Rigidbody c_Rigidbody;
    private bool isGrounded;
    float c_OrigGroundCheckDistance;
    const float k_Half = 0.5f;
    float c_TurnAmount;
    float c_ForwardAmount;
    Vector3 c_GroundNormal;
    bool doubleJump;

    //CapsuleCollider c_Capsule;

    //Model fields
    private Transform modelTransform;
    private Quaternion modelRotation;

    void Start()
    {
        c_Rigidbody = GetComponent<Rigidbody>();
        modelTransform = GameObject.Find("PascalModel").transform;
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
        checkForReset();

        float h = CrossPlatformInputManager.GetAxis("Horizontal");

        if(h > 0)
        {
            modelTransform.rotation = Quaternion.Lerp(modelTransform.rotation, Quaternion.Euler(0, 90, 0), 0.4f);
        }
        else if(h < 0)
        {
            
            modelTransform.rotation = Quaternion.Lerp(modelTransform.rotation, Quaternion.Euler(0, 270, 0), 0.4f);
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

        //c_Rigidbody.position = transform.position +  (c_Move* MoveSpeedMultiplier);

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
        //c_Move = transform.InverseTransformDirection(c_Move);
        CheckGroundStatus();
        c_Move = Vector3.ProjectOnPlane(c_Move, c_GroundNormal);
        c_ForwardAmount = c_Move.x  ;

        //ApplyExtraTurnRotation();

        if (isGrounded)
        {
            HandleGroundedMovement();
        }
        else
        {
            HandleAirborneMovement();
        }

        c_Rigidbody.position = transform.position + (c_Move * MoveSpeedMultiplier);
        //UpdateAnimator();
    }

    //void UpdateAnimator()
    //{
    //    //Update animator parameters
    //    c_Animator.SetFloat("Forward", c_ForwardAmount, 0.1f, Time.deltaTime);
    //    c_Animator.SetFloat("Turn", c_TurnAmount, 0.1f, Time.deltaTime);
    //    c_Animator.SetBool("OnGround", isGrounded);

    //    if (!isGrounded)
    //    {
    //        c_Animator.SetFloat("Jump", c_Rigidbody.velocity.y);
    //    }

    //    float runCycle = Mathf.Repeat(c_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + RunCycleLegOffset, 1);
    //    float jumpLeg = (runCycle < k_Half ? 1 : -1) * c_ForwardAmount;

    //    if (isGrounded)
    //    {
    //        c_Animator.SetFloat("JumpLeg", jumpLeg);

    //    }

    //    if (isGrounded && c_Move.magnitude > 0)
    //    {
    //        c_Animator.speed = AnimSpeedMultiplier;
    //    }
    //    else
    //    {
    //        c_Animator.speed = 1;
    //    }
    //}

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
        c_Rigidbody.velocity = new Vector3(c_Rigidbody.velocity.x, JumpPower, c_Rigidbody.velocity.z);
        isGrounded = false;
        //c_Animator.applyRootMotion = false;
        //GroundCheckDistance = 0.1f;
    }

    //void ApplyExtraTurnRotation()
    //{
    //    float turnSpeed = Mathf.Lerp(StationaryTurnSpeed, MovingTurnSpeed, c_ForwardAmount);
    //    transform.Rotate(0, c_TurnAmount * turnSpeed * Time.deltaTime, 0);
    //}

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
        RaycastHit hitInfo;
#if UNITY_EDITOR
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * GroundCheckDistance));
#endif
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, GroundCheckDistance))
        {
            c_GroundNormal = hitInfo.normal;
            isGrounded = true;
            doubleJump = false;
            //c_Animator.applyRootMotion = true;
        }
        else
        {
            isGrounded = false;
            c_GroundNormal = Vector3.up;
            //c_Animator.applyRootMotion = false;
        }
    }

    void checkForReset()
    {
        if(transform.position.y < -25)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadScene("scene 1");
            UnityEngine.SceneManagement.SceneManager.LoadScene("scene 1");

        }
    }
}
