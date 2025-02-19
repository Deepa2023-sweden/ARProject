using UnityEngine;
using UnityEngine.UI;

public class CategoryManager : MonoBehaviour
{
    public GameObject colorPanel; // Reference to the color selection panel
    public GameObject sofaPanel; // Reference to the sofa color selection panel

    public void OnSofaSelected()
    {
        // Hide category panel and show color panel
        colorPanel.SetActive(true);
        sofaPanel.SetActive(true);
    }

    // Add similar methods for Bed, Side Table, and Table
}