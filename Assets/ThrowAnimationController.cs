using UnityEngine;

public class ThrowAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the character
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the G key is pressed
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Trigger the throw animation
            animator.SetTrigger("Throw");
        }
    }
}
