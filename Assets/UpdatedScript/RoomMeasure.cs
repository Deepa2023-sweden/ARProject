using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;


public class RoomMeasure : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject pointPrefab;
    public LineRenderer lineRenderer;
    public TextMeshProUGUI measurementText;

    private List<Vector3> points = new List<Vector3>();
    private float measuredHeight = 0f;
    private float measuredWidth = 0f;

    void Start()
    {
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinBounds))
            {
                Pose hitPose = hits[0].pose;
                TrackableType surfaceType = hits[0].hitType;

                points.Add(hitPose.position);
                Instantiate(pointPrefab, hitPose.position, Quaternion.identity);

                // Draw Line
                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPositions(points.ToArray());

                // Detect if measuring Wall (Vertical) or Floor/Furniture (Horizontal)
                if (points.Count >= 2)
                {
                    if (surfaceType == TrackableType.PlaneWithinPolygon)
                    {
                        measuredWidth = Vector3.Distance(points[points.Count - 2], points[points.Count - 1]);
                        measurementText.text = "Width: " + measuredWidth.ToString("F2") + " meters";
                    }
                    else if (surfaceType == TrackableType.PlaneWithinBounds)
                    {
                        measuredHeight = Vector3.Distance(points[points.Count - 2], points[points.Count - 1]);
                        measurementText.text = "Height: " + measuredHeight.ToString("F2") + " meters";
                    }
                }

                // Measure furniture dimensions (Height x Width x Depth)
                if (points.Count == 3)
                {
                    float depth = Vector3.Distance(points[1], points[2]);
                    measurementText.text = $"Furniture: {measuredWidth:F2}m x {measuredHeight:F2}m x {depth:F2}m";
                }
            }
        }
    }
}
