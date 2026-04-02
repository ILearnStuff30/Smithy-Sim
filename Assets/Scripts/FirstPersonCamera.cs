using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform direction;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        // To ensure that the cursor does not move and is not seen during game play
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the mouse input and sets the mouse sensitivity
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate the camera and the direction of the player rigidbody
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        direction.rotation = Quaternion.Euler(0, yRotation, 0);
    }

}

