using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraController : MonoBehaviour
{
    public GameObject focusTarget;

    // 0.0 ~ 1.0, lerp ratio per fixed update
    public float cameraSpeed = 0.25f;

    public Vector2 offset = new Vector2(0, 0);

    // For interpolation
    Vector2 previousPosition = Vector2.zero;
    Vector2 nextPosition = Vector2.zero;


    void Update()
    {
        // Framerate-independent position interpolation
        var interpolateDelta = (Time.time - Time.fixedTime) / Time.fixedDeltaTime;
        interpolateDelta = Mathf.Clamp(interpolateDelta, 0.0f, 1.0f);
        SetPosition2(Vector2.Lerp(previousPosition, nextPosition, interpolateDelta));
    }

    void FixedUpdate()
    {
        previousPosition = nextPosition;
        SetPosition2(previousPosition);
        nextPosition = Vector2.Lerp(previousPosition, GetDesiredPosition(), cameraSpeed);
    }


    void SetPosition2(Vector2 v)
    {
        v += offset;

        // Snap to pixel
        var newX = Mathf.Round(v.x * 100) / 100;
        var newY = Mathf.Round(v.y * 100) / 100;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    Vector2 GetDesiredPosition()
    {
        // Find all landmarks within the radius of the target position
        var targetPos = GetTargetPosition();
        var landmarks = FindObjectsByType<CameraLandmark>(FindObjectsSortMode.None)
            .Where(landmark => Vector2.Distance(landmark.transform.position, targetPos) <= landmark.radius);

        // Calculate the weighted average of landmarks' position (including the target position)
        var totalWeight = landmarks.Sum(landmark => landmark.weight) + 1.0f;
        var averagePos = landmarks
            .Select(landmark => (Vector2) landmark.transform.position * landmark.weight)
            .Append(targetPos)
            .Aggregate((acc, pos) => acc + pos) / totalWeight;

        return averagePos;
    }

    Vector2 GetTargetPosition()
    {
        return focusTarget?.transform.position ?? Vector2.zero;
    }
}
