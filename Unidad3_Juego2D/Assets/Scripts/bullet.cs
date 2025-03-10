using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        EnemyScript enemy = hit.GetComponent<EnemyScript>();
        Movement player = hit.GetComponent<Movement>();
        if (enemy != null)
        {
            enemy.Hit();
        }
        if (player != null)
        {
            player.Hit();
        }
        DestroyBullet();
    }
}
