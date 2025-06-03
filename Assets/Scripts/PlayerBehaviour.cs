using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Kiểm tra groundCheck đã được gán chưa
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck chưa được gán trong Inspector.");
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Map 3")
        {
            Debug.Log("Player is in Map 3");
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput) * Time.deltaTime * 5f;
            transform.Translate(movement, Space.World);
        }
        // Kiểm tra chạm đất
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        if (SceneManager.GetActiveScene().name == "Map 2")
        {
            HandleMap2(); 
        }
        if (SceneManager.GetActiveScene().name == "Map 1")
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (Input.GetMouseButtonDown(0)) 
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

        }
    }

    void HandleMap2()
    {
        // Di chuyển bằng phím A/D hoặc mũi tên trái/phải
        float moveInput = Input.GetAxisRaw("Horizontal"); // -1 trái, 1 phải
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Nhảy nếu nhấn phím cách và đang chạm đất
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}