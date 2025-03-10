using UnityEngine;
using UnityEngine.UI; 

public class GameController : MonoBehaviour
{
    public Button closeButton; 

    void Start()
    {
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CerrarJuego); 
        }
        else
        {
            Debug.LogError("El botón 'closeButton' no está asignado en el Inspector.");
        }
    }

    void CerrarJuego()
    {
        Debug.Log("Cerrando el juego...");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}