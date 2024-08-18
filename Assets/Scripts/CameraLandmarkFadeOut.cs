using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLandmarkFadeOut : MonoBehaviour
{
    public float duration = 5.0f;
    CameraLandmark landmark;
    float initialWeight;
    float time = 0;
    [SerializeField]
    private GameObject tutorialUI;

    public GameObject messageBoxHolder;
    public GameObject messageBoxPrefab;

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
            if (tutorialUI != null)
            {
                tutorialUI.SetActive(true);
            }

            if (messageBoxHolder != null)
            {
                ShowText("기억이 없어... 어떻게 된 거지?");
            }

            gameObject.SetActive(false);
        }
    }

    void ShowText(string text)
    {
        var messageBox = Instantiate(messageBoxPrefab, messageBoxHolder.transform);
        messageBox.GetComponent<MessageBox>().content = text;
        messageBox.transform.SetAsFirstSibling();
    }
}
