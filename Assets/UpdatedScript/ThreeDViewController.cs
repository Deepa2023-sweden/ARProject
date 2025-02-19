using UnityEngine;
using UnityEngine.SceneManagement;

public class ThreeDViewController : MonoBehaviour
{
    public Transform modelContainer;
    private GameObject selectedModel;

    void Start()
    {
        string modelName = PlayerPrefs.GetString("SelectedModel");
        selectedModel = Resources.Load<GameObject>(modelName);
        Instantiate(selectedModel, modelContainer);
    }

    public void LoadARView()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("CategorySelection");
    }
}
