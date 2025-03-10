using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{

    public GameObject player;

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
        Vector3 position = transform.position;
        position.x = player.transform.position.x;
        transform.position = position;
    }
}
