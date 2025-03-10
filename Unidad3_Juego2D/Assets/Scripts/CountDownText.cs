using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountdownText : MonoBehaviour
{
    public Text countdownText; 
    private float countdownTime; 
    public bool isMenu;

    void Start()
    {
        if (isMenu)
        {
            StartCoroutine(StartCountdownCoroutine());
        }
        else
        {
            StartCoroutine(CountdownCoroutine());
        }
    }

    IEnumerator CountdownCoroutine()
    {
        countdownTime = 5f;
        while (countdownTime > 0)
        {
            countdownText.text = "El juego va a reinicar en " + Mathf.Ceil(countdownTime) + " segundos"; 
            countdownTime -= Time.deltaTime; 
            yield return null; 
        }

        countdownText.text = "¡Comienza el juego!";
        StartGame();
    }

    IEnumerator StartCountdownCoroutine()
    {
        countdownTime = 10f;
        while (countdownTime > 0)
        {
            countdownText.text = "El juego va a comenzar en " + Mathf.Ceil(countdownTime) + " segundos"; 
            countdownTime -= Time.deltaTime; 
            yield return null; 
        }

        countdownText.text = "¡Comienza el juego!";
        StartGame();
    }

    private void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("SampleScene");  
    }
}