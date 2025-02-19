using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public GameObject categoryPanel;        // The panel with category buttons
    public GameObject modelPanel;           // The panel to display models
    public Transform modelButtonContainer;  // A container (e.g., GridLayout) to hold model buttons
    public Button modelButtonPrefab;        // A button prefab to instantiate for each model
    private string selectedCategory;        // Stores the selected category

    private Dictionary<string, List<string>> categoryModels = new Dictionary<string, List<string>>()
    {
        { "Sofa", new List<string> { "Sofa1", "Sofa2" } },
        { "Bed", new List<string> { "Bed1", "Bed2" } },
        { "Table", new List<string> { "Table1" , "Table2" } },
        { "Sidetable", new List<string> { "Sidetable1", "Sidetable2" } }
    };

    public void SelectCategory(string category)
    {
        selectedCategory = category;
        Debug.Log("Category Selected: " + selectedCategory);

        categoryPanel.SetActive(false);
        modelPanel.SetActive(true);

        foreach (Transform child in modelButtonContainer)
        {
            Destroy(child.gameObject);
        }

        if (categoryModels.ContainsKey(category))
        {
            foreach (string modelName in categoryModels[category])
            {
                Button modelButton = Instantiate(modelButtonPrefab, modelButtonContainer);
                modelButton.GetComponentInChildren<TMP_Text>().text = modelName;
                modelButton.onClick.AddListener(() => SelectModel(modelName));
            }
        }
        else
        {
            Debug.LogError($"No models found for category: {category}");
        }
    }

    public void SelectModel(string modelName)
    {
        if (string.IsNullOrEmpty(modelName))
        {
            Debug.LogError("No model selected!");
            return;
        }

        Debug.Log("Model Selected: " + modelName);
        PlayerPrefs.SetString("SelectedModel", modelName);
        PlayerPrefs.Save();
        SceneManager.LoadScene("ARScene");
    }
}
