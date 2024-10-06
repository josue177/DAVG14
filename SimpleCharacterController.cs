using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.8f;
    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
    }

    private void MoveCharacter()
    {
        // Corrected variable names and syntax
        var moveInput = Input.GetAxis("Horizontal"); // Access input from Input.GetAxis
        var move = new Vector3(moveInput, 0f, 0f) * (moveSpeed * Time.deltaTime); // Corrected "var move Vector3" to proper variable initialization
        controller.Move(move);
        
        // Jump logic correction
        if (Input.GetButtonDown("Jump") && controller.isGrounded) // Input should come from Input class
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Jump calculation remains unchanged
        }
    }    

    private void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime; // Gravity applied when not grounded
        }
        else
        {
            velocity.y = 0f; // Reset vertical velocity when grounded
        }

        controller.Move(velocity * Time.deltaTime); // Apply vertical movement (gravity and jump)
    } 

    private void KeepCharacterOnXAxis()
    {
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f; // Restrict movement to X-axis only
        thisTransform.position = currentPosition;
    }
}
