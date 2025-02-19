using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject categoryPanel, modelPanel, viewPanel;
    public GameObject[] sofas, beds, tables, sideTables; // Assign in Inspector
    private GameObject currentModel;

    public void SelectCategory(string category)
    {
        categoryPanel.SetActive(false);
        modelPanel.SetActive(true);
        // Show relevant models based on category
    }

    public void SelectModel(GameObject model)
    {
        if (currentModel) Destroy(currentModel);
        currentModel = Instantiate(model, Vector3.zero, Quaternion.identity);
        modelPanel.SetActive(false);
        viewPanel.SetActive(true);
    }

    public void SwitchTo3DView()
    {
        // Show model in standard 3D scene
    }

    public void SwitchToARView()
    {
        // Load AR scene (or activate AR session)
    }
}