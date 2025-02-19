using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelViewer : MonoBehaviour
{
    private GameObject currentModel;

    void Start()
    {
        string selectedModelName = PlayerPrefs.GetString("SelectedModel", "");
        if (string.IsNullOrEmpty(selectedModelName))
        {
            Debug.LogError("No model selected!");
            return;
        }

        // The model will be instantiated by the InputManager script
        Debug.Log("ModelViewer initialized.");
    }

    // Add model manipulation logic here if needed (e.g., scaling, rotation)
}
