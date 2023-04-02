using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    Rigidbody rb;

    [Header("Movement")]
    public float speed = 7f;

    [Header("Ground Check")]

    public float playerHeight;
    public LayerMask whatIsGround;
    bool isOnGround;



    public Vector3 movementDirection;
    public Transform orientation;
    float horizonalInput;
    float verticalInput;
    public float groundDrag = 1f;

    public float jumpForce = 12f;
    public float jumpCooldown = 0.25f;
    public float airMultiplier = 0.4f;
    public KeyCode jumpKey = KeyCode.Space;
    bool rdyForJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        isOnGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f - 1f , whatIsGround);
        //MOVEMENT
        moveCharacter();
        SpeedControll();
        if (isOnGround)
        {
            rb.drag = groundDrag;

        }
        else
        {
            rb.drag = 0f;
        }
    }
    void FixedUpdate()
    {
        
        MovePlayer();
        
    }
    void MovePlayer()
    {
        movementDirection = (orientation.forward * verticalInput) + (orientation.right * horizonalInput);
        if(isOnGround)
            rb.AddForce(movementDirection.normalized * speed * 10f, ForceMode.Force);
        else if(!isOnGround)
            rb.AddForce(movementDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
    }
    void moveCharacter()
    {
        horizonalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        //jump
        if (Input.GetKey(jumpKey) && rdyForJumping && isOnGround)
        {
            rdyForJumping = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void SpeedControll()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        rdyForJumping = true;
    }
}
