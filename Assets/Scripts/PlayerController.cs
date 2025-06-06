using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidBody;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float speed;

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 InputValue = context.ReadValue<Vector2>();
        Vector2 NewVelocity = speed * InputValue;
        NewVelocity.Normalize();
        rigidBody.linearVelocity = NewVelocity;
        animator.SetFloat("SpeedX", NewVelocity.x);
        animator.SetFloat("SpeedY", NewVelocity.y);

        if (InputValue.x > 0.1)
        {
            animator.SetFloat("LastX", 1.0f);
        }

        if (InputValue.y > 0.1)
        {
            animator.SetFloat("LastY", 1.0f);
        }

        if (InputValue.x < -0.1)
        {
            animator.SetFloat("LastX", -1.0f);
        }

        if (InputValue.y < -0.1)
        {
            animator.SetFloat("LastY", -1.0f);
        }
    }
}
