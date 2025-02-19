using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject categorySelectionPanel;
    public GameObject view3DPanel;

    public Transform modelContainer;
    private GameObject selectedModel;

    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        categorySelectionPanel.SetActive(false);
        view3DPanel.SetActive(false);
    }

    public void ShowCategorySelection(string category)
    {
        PlayerPrefs.SetString("SelectedCategory", category);
        mainMenuPanel.SetActive(false);
        categorySelectionPanel.SetActive(true);
        view3DPanel.SetActive(false);
    }

    public void Show3DView(string color)
    {
        PlayerPrefs.SetString("SelectedColor", color);
        mainMenuPanel.SetActive(false);
        categorySelectionPanel.SetActive(false);
        view3DPanel.SetActive(true);

        LoadSelectedModel();
    }

    public void LoadSelectedModel()
    {
        string modelName = PlayerPrefs.GetString("SelectedCategory") + "_" + PlayerPrefs.GetString("SelectedColor");
        selectedModel = Resources.Load<GameObject>(modelName);
        Instantiate(selectedModel, modelContainer);
    }

    public void LoadARView()
    {
        SceneManager.LoadScene("ARScene"); // Assumes ARScene is a separate AR setup scene
    }
}
