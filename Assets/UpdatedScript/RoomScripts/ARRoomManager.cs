using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARRoomManager : MonoBehaviour
{
    public ARRaycastManager raycastManager; // Detects planes
    public ARAnchorManager anchorManager; // Adds anchors
    public GameObject roomPrefab; // Virtual room model
    public GameObject teleportMarkerPrefab; // Marker for teleport points
    public List<Transform> teleportPoints; // List of teleport locations

    private GameObject spawnedRoom;
    private ARAnchor roomAnchor;

    void Update()
    {
        // Only allow placing the room and plane once
        if (spawnedRoom == null && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceRoom();
        }
    }

    void PlaceRoom()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        // Raycast to detect a plane once
        if (raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            // Instantiate the room only once
            spawnedRoom = Instantiate(roomPrefab, hitPose.position, hitPose.rotation);

            // Anchor the room to the detected plane
            roomAnchor = spawnedRoom.AddComponent<ARAnchor>();

            Debug.Log("Room placed and anchored to a static plane!");

            // Place teleport points after the room is anchored
            PlaceTeleportPoints();
        }
    }

    void PlaceTeleportPoints()
    {
        foreach (Transform point in teleportPoints)
        {
            GameObject marker = Instantiate(teleportMarkerPrefab, point.position, Quaternion.identity);
            marker.GetComponent<TeleportPoint>().SetRoomManager(this);
        }
    }

    public void TeleportPlayer(Vector3 newPosition)
    {
        Camera.main.transform.position = newPosition;
        Debug.Log("Player teleported!");
    }
}
