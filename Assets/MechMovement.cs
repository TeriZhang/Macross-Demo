using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMovement : MonoBehaviour
{
    public CharacterController mechCtrl;
    public Transform mechCam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSpeed = 10f;
    float turnSmoothVelocity;

    public float jumpForce = 5.0f; // Adjust this value for the jump height

    private bool isGrounded; // Check if the character is on the ground
    private float verticalVelocity = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        mechCtrl = GetComponent<CharacterController>();
        mechCam = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //if (direction.magnitude > 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mechCam.eulerAngles.y;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //    transform.rotation = Quaternion.Euler(0f, angle, 0f);

        //    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //    mechCtrl.Move(moveDir.normalized * speed * Time.deltaTime);
        //}

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the move direction relative to the camera's forward
        Vector3 moveDirection = mechCam.forward * verticalInput + mechCam.right * horizontalInput;
        moveDirection.y = 0; // Ensure movement stays in the horizontal plane

        


        // Normalize the direction to maintain consistent speed regardless of diagonal movement
        if (moveDirection != Vector3.zero)
        {
            // Rotate the character to face the move direction
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, turnSpeed * Time.deltaTime);

            mechCtrl.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(mechCam.forward * speed * Time.deltaTime);
        //}
    }
}
