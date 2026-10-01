using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float fastFallForce = 30f;
    public Transform shadow;

    public float jumpBufferTime = 0.1f;

    private Rigidbody rb;

    private float horizontalInput;
    private float jumpBufferCounter;

    private bool jumpPressed;
    private bool isGrounded;
    private bool fastFallPressed;

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

        // Placing Shadow on the ground

        RaycastHit shadowHit;

        if (Physics.Raycast(
            transform.position + Vector3.up * 0.05f,
            Vector3.down,
            out shadowHit,
            20f))
        {
            Vector3 vector3 = shadowHit.point + Vector3.up * 0.01f;
            shadow.position = vector3;
        }

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

        // Buffered jump is ready
        if (jumpBufferCounter > 0 && isGrounded)
        {
            jumpPressed = true;
            jumpBufferCounter = 0;
        }

        // Fast fall set to ctrl
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Ctrl was Pressed!");
            fastFallPressed = true;
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

        // Perform a fast fall 
        if (fastFallPressed)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                -5f,
                rb.linearVelocity.z
                );

            fastFallPressed = false;
        }

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