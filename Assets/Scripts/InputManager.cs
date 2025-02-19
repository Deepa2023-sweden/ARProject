using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private ARPlaneManager arPlaneManager;  // Reference to the ARPlaneManager

    private GameObject spawnedObject = null;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Pose pose;
    private GameObject selectedFurniturePrefab;
    private bool isObjectSelected = false;

    void Start()
    {
        string selectedModelName = PlayerPrefs.GetString("SelectedModel", "");
        if (string.IsNullOrEmpty(selectedModelName))
        {
            Debug.LogError("No model selected!");
            return;
        }

        string path = $"Models/{selectedModelName}";
        selectedFurniturePrefab = Resources.Load<GameObject>(path);

        if (selectedFurniturePrefab == null)
        {
            Debug.LogError($"Model NOT found at path: {path}. Check folder structure and naming.");
        }

        // Disable the plane visualization on start
        if (arPlaneManager != null)
        {
            foreach (var plane in arPlaneManager.trackables)
            {
                // Disable the plane's visual representation (MeshRenderer)
                plane.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "ARScene") return;

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (!IsPointerOverUI(touch))
            {
                if (raycastManager.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds))
                {
                    pose = hits[0].pose;

                    if (touch.phase == TouchPhase.Began)
                    {
                        if (spawnedObject == null && selectedFurniturePrefab != null)
                        {
                            spawnedObject = Instantiate(selectedFurniturePrefab, pose.position, pose.rotation);
                        }
                        else
                        {
                            isObjectSelected = true;
                        }
                    }
                    else if (touch.phase == TouchPhase.Moved && isObjectSelected && spawnedObject != null)
                    {
                        spawnedObject.transform.position = pose.position;
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        isObjectSelected = false;
                    }
                }
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
            {
                Vector2 prevTouchZeroPos = touchZero.position - touchZero.deltaPosition;
                Vector2 prevTouchOnePos = touchOne.position - touchOne.deltaPosition;
                float prevAngle = Vector2.Angle(prevTouchZeroPos, prevTouchOnePos);

                float angle = Vector2.Angle(touchZero.position, touchOne.position);
                float angleDelta = angle - prevAngle;

                if (spawnedObject != null)
                {
                    spawnedObject.transform.Rotate(Vector3.up, -angleDelta);
                }
            }
        }

        UpdateCrosshair();
    }

    private bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    private void UpdateCrosshair()
    {
        if (crosshair == null) return;

        Vector3 screenCenter = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        Ray ray = arCam.ScreenPointToRay(screenCenter);

        if (raycastManager.Raycast(ray, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds))
        {
            pose = hits[0].pose;
            crosshair.SetActive(true);
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);
        }
        else
        {
            crosshair.SetActive(false);
        }
    }
}
