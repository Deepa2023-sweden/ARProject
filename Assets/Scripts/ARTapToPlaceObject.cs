using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ARTapToPlaceAndMoveObject : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject whiteSofaPrefab;
    public GameObject blackSofaPrefab;

    private GameObject placedObject;
    private Vector2 initialTouchPosition;
    private Quaternion initialRotation;

    public static string SelectedColor;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "ARScene") return;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;

            if (raycastManager.Raycast(touchPosition, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;

                if (placedObject == null)
                {
                    if (SelectedColor == "White")
                        placedObject = Instantiate(whiteSofaPrefab, hitPose.position, hitPose.rotation);
                    else if (SelectedColor == "Black")
                        placedObject = Instantiate(blackSofaPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    placedObject.transform.position = hitPose.position;
                }
            }
        }
        else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (placedObject != null)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                if (raycastManager.Raycast(touchPosition, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;
                    placedObject.transform.position = hitPose.position;
                }
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(1);
            if (touch.phase == TouchPhase.Began)
            {
                initialTouchPosition = touch.position;
                initialRotation = placedObject.transform.rotation;
            }
            else if (touch.phase == TouchPhase.Moved && placedObject != null)
            {
                float rotationAmount = (touch.position.x - initialTouchPosition.x) * 0.1f;
                placedObject.transform.rotation = initialRotation * Quaternion.Euler(0, rotationAmount, 0);
            }
        }
    }
}
