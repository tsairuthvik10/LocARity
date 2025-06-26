using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARAnchorHandler : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public ARAnchorManager anchorManager;
    public GameObject treasurePrefab;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount == 0 || Input.GetTouch(0).phase != TouchPhase.Began)
            return;

        Vector2 touchPosition = Input.GetTouch(0).position;

        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            ARPlane plane = hits[0].trackable as ARPlane;

            ARAnchor anchor = anchorManager.AttachAnchor(plane, hitPose);
            if (anchor != null)
            {
                Instantiate(treasurePrefab, anchor.transform);
                Debug.Log("Treasure spawned at anchor.");
            }
            else
            {
                Debug.LogWarning("Failed to attach anchor to plane.");
            }
        }
    }
}
