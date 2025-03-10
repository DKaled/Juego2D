using UnityEngine;
using TMPro;

public class DatabaseManager : MonoBehaviour
{
    public TextMeshProUGUI monedasText; // UI donde se mostrará la cantidad de monedas (TextMeshPro)
    private int monedas;
    private string id;

    void Start()
    {
        id = SystemInfo.deviceUniqueIdentifier;
        monedas = PlayerPrefs.GetInt("monedas", 0);
        Debug.Log("Monedas cargadas desde PlayerPrefs: " + monedas);
        ActualizarTextoMonedas();
    }

    public void AgregarMoneda()
    {
        monedas++; 
        Debug.Log("Monedas incrementadas a: " + monedas);

      
        PlayerPrefs.SetInt("monedas", monedas);
        PlayerPrefs.Save(); 

        ActualizarTextoMonedas(); 
    }

    private void ActualizarTextoMonedas()
    {
        if (monedasText == null)
        {
            Debug.LogError("El campo 'monedasText' no está asignado en el Inspector.");
            return; 
        }

        monedasText.text = "Monedas: " + monedas;
    }
}