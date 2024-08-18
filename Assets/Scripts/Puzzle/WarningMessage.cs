using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningMessage : MonoBehaviour
{
    [SerializeField]
    private int delaySeconds;

    private void OnEnable()
    {
        StartCoroutine(HideUI(delaySeconds));
    }

    private IEnumerator HideUI(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
