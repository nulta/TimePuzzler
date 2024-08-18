using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class MessageBox : MonoBehaviour
{
    TMP_Text text;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    AudioSource audioSource;

    public string content = "";
    float preferredY;

    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        audioSource = GetComponent<AudioSource>();
        preferredY = transform.GetSiblingIndex() * 55;

        StartCoroutine(FadeIn());
        StartCoroutine(ShowMessage());
    }

    void Update()
    {
        preferredY = transform.GetSiblingIndex() * 55;
    }

    IEnumerator ShowMessage()
    {
        while (text.text.Length != content.Length) {
            text.text += content[text.text.Length];
            rectTransform.sizeDelta = new Vector2(text.preferredWidth + 40, 44);
            audioSource.Play();
            yield return new WaitForSeconds(0.07f);
        }
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        var lerp = 0.0f;
        while (lerp < 1) {
            lerp += Time.deltaTime / 0.25f;
            var value = 1f - Mathf.Clamp01(Mathf.Pow(1f - lerp, 4));

            canvasGroup.alpha = value;
            rectTransform.anchoredPosition = new Vector2(
                rectTransform.anchoredPosition.x,
                preferredY - 15.0f * (1.0f - value)
            );
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        var lerp = 0.0f;
        while (lerp < 1) {
            lerp += Time.deltaTime / 0.25f;
            var value = Mathf.Clamp01(Mathf.Pow(lerp, 4));

            canvasGroup.alpha = 1f - value;
            rectTransform.anchoredPosition = new Vector2(
                rectTransform.anchoredPosition.x,
                preferredY - 15.0f * value
            );
            yield return null;
        }
        Destroy(gameObject);
    }
}
