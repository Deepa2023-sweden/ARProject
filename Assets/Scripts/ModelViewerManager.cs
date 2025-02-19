using UnityEngine;

public class ModelViewerManager : MonoBehaviour
{
    public GameObject whiteSofaPrefab;
    public GameObject blackSofaPrefab;

    void Start()
    {
        GameObject modelToLoad = GameManager.instance.selectedModel; // Pass this dynamically
        Instantiate(modelToLoad, Vector3.zero, Quaternion.identity);
    }
}
