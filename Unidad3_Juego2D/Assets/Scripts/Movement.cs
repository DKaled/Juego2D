using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private float hMovement;
    private bool isGrounded;
    private Animator anim;
    private float lastShoot;
    private int health = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hMovement = Input.GetAxisRaw("Horizontal");

        if (hMovement < 0.0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (hMovement > 0.0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetBool("running", hMovement != 0.0f);

        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastShoot > 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        GameObject bullet = Instantiate(bulletPrefab, transform.position + direction * 0.2f, Quaternion.identity);
        bullet.GetComponent<bullet>().SetDirection(direction);
    }
        

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(hMovement * speed, rb.linearVelocity.y);
    }
    
    public void Hit()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

}
