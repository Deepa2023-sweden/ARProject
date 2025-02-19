using UnityEngine;

public class GestureHandler : MonoBehaviour
{
    private Touch touch0, touch1;
    private Vector2 touch0PrevPos, touch1PrevPos;
    private float initialDistance, currentDistance;
    private float initialAngle, currentAngle;

    private float rotationSpeed = 0.2f; // Adjust rotation sensitivity
    private float scaleSpeed = 0.005f; // Adjust scale sensitivity
    private float minScale = 0.1f; // Minimum scale limit
    private float maxScale = 3.0f; // Maximum scale limit

    private Vector3 initialPosition;
    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main; // Get AR Camera
    }

    void Update()
    {
        // Handle gestures only if there are active touches
        if (Input.touchCount == 1)
        {
            HandleMovement();
        }
        else if (Input.touchCount == 2)
        {
            HandleScalingAndRotation();
        }
    }

    void HandleMovement()
    {
        touch0 = Input.GetTouch(0);

        if (touch0.phase == TouchPhase.Moved)
        {
            // Convert screen touch position to world position
            Ray ray = arCamera.ScreenPointToRay(touch0.position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Move the object to the touch position on the AR plane
                transform.position = hit.point;
            }
        }
    }

    void HandleScalingAndRotation()
    {
        touch0 = Input.GetTouch(0);
        touch1 = Input.GetTouch(1);

        // Calculate the distance between touches
        if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
        {
            // Store initial positions for scaling and rotation
            initialDistance = Vector2.Distance(touch0.position, touch1.position);
            initialAngle = Mathf.Atan2(touch1.position.y - touch0.position.y, touch1.position.x - touch0.position.x);
        }
        else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
        {
            // Scale the object
            currentDistance = Vector2.Distance(touch0.position, touch1.position);
            float scaleFactor = (currentDistance - initialDistance) * scaleSpeed;
            Vector3 newScale = transform.localScale + new Vector3(scaleFactor, scaleFactor, scaleFactor);
            newScale = Vector3.Max(newScale, new Vector3(minScale, minScale, minScale)); // Enforce min scale
            newScale = Vector3.Min(newScale, new Vector3(maxScale, maxScale, maxScale)); // Enforce max scale
            transform.localScale = newScale;

            // Rotate the object
            currentAngle = Mathf.Atan2(touch1.position.y - touch0.position.y, touch1.position.x - touch0.position.x);
            float angleDifference = (currentAngle - initialAngle) * Mathf.Rad2Deg;
            transform.Rotate(Vector3.up, angleDifference * rotationSpeed, Space.World);

            // Update for the next frame
            initialDistance = currentDistance;
            initialAngle = currentAngle;
        }
    }
}
