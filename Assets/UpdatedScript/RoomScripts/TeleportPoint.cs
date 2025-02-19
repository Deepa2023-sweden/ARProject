using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    private ARRoomManager roomManager;

    public void SetRoomManager(ARRoomManager manager)
    {
        roomManager = manager;
    }

    void Update()
    {
        // Check for touch input on mobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Perform a raycast to detect the teleport marker
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is this teleport point
                if (hit.collider.gameObject == gameObject && roomManager != null)
                {
                    roomManager.TeleportPlayer(transform.position);
                }
            }
        }
    }
}
