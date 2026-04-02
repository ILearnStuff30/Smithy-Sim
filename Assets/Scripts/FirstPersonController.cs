using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;

    public float horizontalInput;
    public float verticalInput;

    Vector3 moveDirection;

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Gets the vertical and horizontal input from the Input Manager
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
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
}
