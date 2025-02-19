using UnityEngine;

public class ExitApp : MonoBehaviour
{
    // This method will be called when the button is pressed
    public void ExitApplication()
    {
        // Exits the application
        Application.Quit();

        // Note: This line is only for testing in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
