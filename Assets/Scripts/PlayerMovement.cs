using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;       // Speed multiplier
    private Rigidbody2D rb;         

    private Vector2 movement;         // Directional input

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Capture raw input (no smoothing)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        // Assign the directional input to movement vector
        movement = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Move the character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
