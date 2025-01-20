using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float moveSpeed = 3f;
    public float stoppingDistance = .5f;
    private Transform player;
    private Rigidbody2D rb;
    private int _health = 3;
    private bool isDamaged = false;
    private int damage = 10;
    Vector2 direction = Vector2.zero;
    private SpriteManager spriteManager;
    private void Start()
    {
        _health = 2;
        spriteManager = GetComponent<SpriteManager>();
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
        if (isDamaged) return;
        direction = (player.position - transform.position).normalized;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            TakeDamage();
        }
        if (collision.gameObject.name == "Player")
        {
            EventManager.PlayerDamaged(damage);
        }
    }

    private void TakeDamage()
    {
        if (!isDamaged && player != null)
        {
            {
                isDamaged = true;
                Vector2 knockbackDirection = (transform.position - player.position).normalized;
                float knockbackDistance = 5f;
                float knockbackDuration = 0.2f;

                StartCoroutine(ApplyKnockback(knockbackDirection, knockbackDistance, knockbackDuration));
            }

            _health--;

            spriteManager.PlayDamageEffect();
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private IEnumerator ApplyKnockback(Vector2 direction, float distance, float duration)
    {
        float elapsed = 0f;
        Vector2 startPos = rb.position;
        Vector2 targetPos = startPos + direction * distance;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            rb.MovePosition(Vector2.Lerp(startPos, targetPos, elapsed / duration));
            yield return null;
        }
        isDamaged = false;
    }
}