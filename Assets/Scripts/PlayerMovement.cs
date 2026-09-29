using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    public float jumpBufferTime = 0.1f;

    private Rigidbody rb;

    private float horizontalInput;
    private float jumpBufferCounter;
    private float jumpDelayCounter;

    private bool jumpPressed;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get A/D or Left/Right input
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Ground check
        RaycastHit hit;

        isGrounded = Physics.Raycast(
            transform.position + Vector3.up * 0.05f,
            Vector3.down,
            out hit,
            0.15f
        );

        // Player pressed Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }

        // Count down jump buffer
        if (jumpBufferCounter > 0)
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // Count down delay between jumps
        if (jumpDelayCounter > 0)
        {
            jumpDelayCounter -= Time.deltaTime;
        }

        // Buffered jump is ready
        if (jumpBufferCounter > 0 && isGrounded)
        {
            jumpPressed = true;
            jumpBufferCounter = 0;
        }
    }

    void FixedUpdate()
    {
        // Left and right movement
        rb.linearVelocity = new Vector3(
            horizontalInput * moveSpeed,
            rb.linearVelocity.y,
            0f
        );

        // Actually perform the jump
        if (jumpPressed)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                0f,
                rb.linearVelocity.z
                );

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            jumpPressed = false;
        }
    }
}