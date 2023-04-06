using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float jumpHeight = 1000f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Camera playerCamera;

    private Vector3 velocity;
    private bool isGrounded;

    private float jumpForce = 16f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = playerCamera.transform.forward * z + playerCamera.transform.right * x;
        moveDirection.y = 0;
        moveDirection.Normalize();

        controller.Move(moveDirection * speed * Time.deltaTime);

        // Rotate player with the camera's Y rotation
        Vector3 newRotation = transform.eulerAngles;
        newRotation.y = playerCamera.transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(newRotation);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("GroundGoop"))
        {
            velocity.y = jumpForce;
        }
    }
}
