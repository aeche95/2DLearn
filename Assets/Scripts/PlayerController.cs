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

    public static PlayerController instance;

    public void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 InputValue = context.ReadValue<Vector2>();
        Vector2 NewVelocity = speed * InputValue;
        NewVelocity.Normalize();
        rigidBody.linearVelocity = NewVelocity;
        animator.SetFloat("SpeedX", NewVelocity.x);
        animator.SetFloat("SpeedY", NewVelocity.y);

        if (InputValue.x > 0.1 || InputValue.x < -0.1)
        {
            animator.SetFloat("LastX", InputValue.x);
        }

        if (InputValue.y > 0.1 || InputValue.y < -0.1)
        {
            animator.SetFloat("LastY", InputValue.y);
        }

    }
}
