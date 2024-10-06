using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;  // Corrected spelling

    // Use Start method to initialize animator
    private void Start()
    {
        animator = GetComponent<Animator>();  // Proper initialization
    }

    private void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        // Trigger "Run" animation when moving horizontally
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }

        // Trigger "Jump" animation on jump button press
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
        }

        // Trigger "WallJump" animation on specific key press
        if (Input.GetKeyDown(KeyCode.W))  // Verify if this is intended for WallJump
        {
            animator.SetTrigger("WallJump");
        }
    }
}
