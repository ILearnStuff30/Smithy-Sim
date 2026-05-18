using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    public float jumpPower = 5f;

 
    public float playerDrag;

    public float playerHeight;
    public LayerMask groundLayer;
    public bool isGrounded;

    public bool canJump;

    public float horizontalInput;
    public float verticalInput;

    Vector3 moveDirection;
    Vector3 jumpDirection;

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

        // Gets the vertical and horizontal input from the Input Manager
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(isGrounded)
        {
            rb.linearDamping = playerDrag;
            canJump = true;
        }
        else
        {
            canJump = false;
            rb.linearDamping = 0;
        }

        SpeedControl();
        JumpCheck();

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // This calculates the movement direction to ensure that they move where they are looking
        moveDirection = playerTransform.forward * verticalInput + playerTransform.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        
        if(flatVelocity.magnitude > speed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * speed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }

    private void JumpCheck()
    {
        jumpDirection = transform.up * jumpPower;

        if(isGrounded && canJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpDirection.normalized * jumpPower * 5f, ForceMode.Impulse);
            canJump = false;
        }
    }
    
}
