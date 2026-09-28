using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(move, 0f, 0f);

        rb.linearVelocity = new Vector3(
            movement.x * moveSpeed,
            rb.linearVelocity.y,
            0f

            );
    }
}
