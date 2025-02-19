using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // This method is called when the button is pressed
    public void LoadARScene()
    {
        // Replace "ARScene" with the name of your AR scene
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMainScene()
    {
        // Replace "MainScene" with the name of your main scene
        SceneManager.LoadScene("_MainScene");
    }

}
