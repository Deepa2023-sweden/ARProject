using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FurnitureSelector : MonoBehaviour
{
    public GameObject[] furnitureModels; // Assign Sofa, Chair, Table GameObjects
    private GameObject currentFurniture;

    public void SelectFurniture(int index)
    {
        // Disable the currently active furniture (if any)
        if (currentFurniture != null)
            currentFurniture.SetActive(false);

        // Enable the selected furniture model
        currentFurniture = furnitureModels[index];
        currentFurniture.SetActive(true);
    }
}
