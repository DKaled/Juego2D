using UnityEngine;

public class moneda : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour es creado
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyMoneda()
    {
        Destroy(gameObject); 
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        Movement player = hit.GetComponent<Movement>();
        if (player != null)
        {
            DestroyMoneda(); 

            DatabaseManager database = FindFirstObjectByType<DatabaseManager>();
            if (database != null)
            {
                database.AgregarMoneda(); 
            }
            else
            {
                Debug.LogError("DatabaseManager no encontrado en la escena");
            }
        }
    }
}