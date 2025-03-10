using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("SampleScene");    
    }

    public void Test() {
        Debug.Log("Test");
    }
}
