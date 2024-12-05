using UnityEngine;

public class MoveUpUntilGrounded : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float groundCheckDistance = 0.1f;

    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the object is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        // Move the object up if it's not grounded
        if (!isGrounded)
        {
            Vector3 moveDirection = Vector3.up;
            rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
