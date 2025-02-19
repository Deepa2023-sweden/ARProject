using UnityEngine;

public class ModelView : MonoBehaviour
{
    public GameObject sofaBlack; // Reference to the black sofa model
    public GameObject sofaWhite; // Reference to the white sofa model

    public void ShowBlackSofa()
    {
        sofaBlack.SetActive(true);
        sofaWhite.SetActive(false);
    }

    public void ShowWhiteSofa()
    {
        sofaBlack.SetActive(false);
        sofaWhite.SetActive(true);
    }
}