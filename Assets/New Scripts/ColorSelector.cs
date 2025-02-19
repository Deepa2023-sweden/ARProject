using UnityEngine;
using System.Collections.Generic;

public class ColorSelector : MonoBehaviour
{
    public Material[] colorMaterials; // Assign materials for different colors
    private Renderer furnitureRenderer;

    public void SelectColor(int colorIndex)
    {
        if (furnitureRenderer == null)
        {
            // Use FindFirstObjectByType to find the first Renderer in the scene
            furnitureRenderer = Object.FindFirstObjectByType<Renderer>();

            if (furnitureRenderer == null)
            {
                Debug.LogError("Renderer not found in the scene!");
                return; // Exit if no Renderer is found
            }
        }

        if (colorIndex >= 0 && colorIndex < colorMaterials.Length)
        {
            furnitureRenderer.material = colorMaterials[colorIndex];
        }
        else
        {
            Debug.LogError($"Invalid color index: {colorIndex}. Ensure it's within the range of colorMaterials.");
        }
    }
}
