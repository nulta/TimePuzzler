using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLandmarkFadeOut : MonoBehaviour
{
    public float duration = 5.0f;
    CameraLandmark landmark;
    float initialWeight;
    float time = 0;

    void OnEnable()
    {
        landmark = GetComponent<CameraLandmark>();
        initialWeight = landmark.weight;
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        landmark.weight = Mathf.Lerp(initialWeight, 0, time / duration);
        if (time >= duration)
        {
            gameObject.SetActive(false);
        }
    }
}
