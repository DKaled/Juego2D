using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    private float lastShoot;
    public GameObject bulletPrefab;
    public int health = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 direction = player.transform.position - transform.position;
        if (direction.x < 0.0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction.x > 0.0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (distance < 0.5f && Time.time - lastShoot > 0.25f)
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

    public void Hit()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");   
        }
    }
}
