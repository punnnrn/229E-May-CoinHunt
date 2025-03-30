using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;
    public Rigidbody rb;

    public float walkSpeed = 4f;
    public float runSpeed = 8f;
    public float crouchSpeed = 2f;
    public float jumpHeight = 7f;
    public float gravity = 20f;
    public float mouseSensitivity = 400f;

    private float normalHeight;

    private float xRotation = 0f;
    private Vector3 velocity;
    private bool isGrounded;

   

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        normalHeight = controller.height;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = crouchSpeed;
            Crouch();
        }
        else
        {
            StandUp();
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    //Scale player down
    private void Crouch()
    {
        float num = 400f;
        base.transform.localScale = new Vector3(1f, 0.1f, 1f);
        base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - 0.1f, base.transform.position.z);
        if (rb.velocity.magnitude > 0.1f && isGrounded)
        {
            rb.AddForce(transform.forward * num);
        }
    }

    //Scale player to original size
    private void StandUp()
    {
        base.transform.localScale = new Vector3(1f, 1f, 1f);
        base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.5f, base.transform.position.z);
    }
}
