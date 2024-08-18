using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningMessage : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(HideUI(2f));
    }

    private IEnumerator HideUI(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
