using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float moveSpeed = 3f;           
    public float stoppingDistance = .5f;    

    private Transform player;              
    private Rigidbody2D rb;                

    private void Start()
    {

        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
