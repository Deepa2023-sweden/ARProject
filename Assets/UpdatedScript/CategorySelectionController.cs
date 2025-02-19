using UnityEngine;
using UnityEngine.SceneManagement;

public class CategorySelectionController : MonoBehaviour
{
    public void Load3DView(string model)
    {
        PlayerPrefs.SetString("SelectedModel", model);
        SceneManager.LoadScene("3DView");
    }
}