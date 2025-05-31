using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocity = new Vector2(4f, rb.linearVelocityY);
    }
}
