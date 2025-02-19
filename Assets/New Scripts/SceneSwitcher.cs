using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneSwitcher : MonoBehaviour
{
    public void LoadModelViewer()
    {
        SceneManager.LoadScene("ModelViewer");
    }// Call this function to switch to the AR Scene
    public void LoadARScene()
    {
        SceneManager.LoadScene("ARScene"); // Replace "ARScene" with the name of your AR scene
    }

    // Optional: Call this function to return to the Main Scene
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene"); // Replace "MainScene" with your UI/3D Viewer scene name
    }
}
