using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadARScene()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void Load3DModelScene()
    {
        SceneManager.LoadScene("3DModelScene");

    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");

    }
}
