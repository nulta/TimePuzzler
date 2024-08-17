using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera landmark: a point of interest for the camera to focus on
/// </summary>
public class CameraLandmark : MonoBehaviour
{
    public float radius = 12.0f;
    public float weight = 2.0f;

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
