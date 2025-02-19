using UnityEngine;

public class FurnitureManipulation : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector3 initialPosition;
    private float rotationSpeed = 0.1f;

    void Update()
    {
        // Handle rotation with touch drag
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                // Rotate object based on horizontal movement
                float rotationAmount = touch.deltaPosition.x * rotationSpeed;
                transform.Rotate(0, -rotationAmount, 0);
            }
        }

        // Handle movement (optional, if you want furniture to be draggable)
        if (Input.touchCount == 2) // Two-finger touch to move
        {
            Touch touch = Input.GetTouch(1);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1f));
                transform.position = newPos;
            }
        }
    }
}
