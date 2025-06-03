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
        // Kiểm tra chạm đất
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        if (SceneManager.GetActiveScene().name == "Map 2")
        {
            HandleMap2();
        }
    }

    void FixedUpdate()
    {
        
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
