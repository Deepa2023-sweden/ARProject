using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARViewManager : MonoBehaviour
{
    public GameObject arSessionOrigin; // AR Session Origin GameObject
    public Camera modelViewerCamera; // Regular 3D viewer camera

    public void ToggleARView(bool isAR)
    {
        arSessionOrigin.SetActive(isAR);
        modelViewerCamera.gameObject.SetActive(!isAR);
    }
}
