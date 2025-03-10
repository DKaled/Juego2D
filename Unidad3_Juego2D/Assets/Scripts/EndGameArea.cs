using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameArea : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        Movement player = hit.GetComponent<Movement>();
        if (player != null)
        {
            SceneManager.LoadScene("SampleScene");   
        }
    }
}
