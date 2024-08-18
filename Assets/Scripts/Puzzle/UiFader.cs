using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UiFader : MonoBehaviour
{
    public float initialDelay = 0.0f;
    public float fadeInDuration = 0.5f;
    public float delayDuration = 3.0f;
    public float fadeOutDuration = 0.5f;

    private void OnEnable()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        float fader = 0.0f;

        canvasGroup.alpha = 0.0f;
        yield return new WaitForSeconds(initialDelay);

        if (fadeInDuration > 0)
        {
            while (fader < 1)
            {
                fader += Time.deltaTime / fadeInDuration;
                canvasGroup.alpha = Mathf.Clamp01(1.0f - Mathf.Pow(1.0f - fader, 4));
                yield return new WaitForEndOfFrame();
            }
        }

        canvasGroup.alpha = 1.0f;
        yield return new WaitForSeconds(delayDuration);

        if (fadeOutDuration > 0)
        {
            fader = 1.0f;
            while (fader > 0)
            {
                fader -= Time.deltaTime / fadeOutDuration;
                canvasGroup.alpha = Mathf.Clamp01(Mathf.Pow(fader, 4));
                yield return new WaitForEndOfFrame();
            }
        }

        canvasGroup.alpha = 1.0f;
        gameObject.SetActive(false);
    }
}
