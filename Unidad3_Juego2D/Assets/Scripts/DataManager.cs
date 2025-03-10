using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        // Obtener la ruta del archivo
        filePath = Application.persistentDataPath + "/gameData.json";
        
        // Depuración para ver la ruta
        Debug.Log("Ruta del archivo: " + filePath);

        // Asegurarse de que la carpeta exista antes de escribir
        string directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);  // Crea la carpeta si no existe
            Debug.Log("Se creó el directorio.");
        }

        // Si el archivo no existe, creamos uno con valores predeterminados
        if (!File.Exists(filePath))
        {
            Debug.Log("Archivo no encontrado. Creando archivo predeterminado.");
            CrearArchivoPredeterminado();  // Crear el archivo con valores iniciales
        }
        else
        {
            Debug.Log("Archivo encontrado.");
        }
    }

    public void GuardarDatos(GameData data)
    {
        // Convertir los datos en JSON y guardarlos en el archivo
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("Datos guardados en: " + filePath);
    }

    public GameData CargarDatos()
    {
        if (File.Exists(filePath))
        {
            Debug.Log("Cargando datos desde: " + filePath);
            string json = File.ReadAllText(filePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Monedas cargadas: " + loadedData.monedas);
            return loadedData;
        }

        Debug.LogWarning("Archivo no encontrado. Devolviendo valores predeterminados.");
        return new GameData { id = SystemInfo.deviceUniqueIdentifier, monedas = 0 };  
    }

    private void CrearArchivoPredeterminado()
    {
        GameData predeterminado = new GameData
        {
            id = SystemInfo.deviceUniqueIdentifier, 
            monedas = 0
        };
        GuardarDatos(predeterminado); 
    }
}

[System.Serializable]
public class GameData
{
    public int monedas;
    public string id;
}