using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public GameObject arScene; // Reference to the AR scene
    public GameObject modelViewer; // Reference to the 3D model viewer

    public void OnBlackSelected()
    {
        // Load black sofa model
        Debug.Log("Black Sofa Selected");
        // Proceed to the next step
    }

    public void OnWhiteSelected()
    {
        // Load white sofa model
        Debug.Log("White Sofa Selected");
        // Proceed to the next step
    }
}