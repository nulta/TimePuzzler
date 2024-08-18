using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSomethingOnActive : MonoBehaviour
{
    public GameObject target;
    public bool activateOnDisable = false;
    public bool invert = false;

    private void OnEnable()
    {
        if (target != null)
        {
            target.SetActive(invert);
        }
    }

    private void OnDisable()
    {
        if (target != null && activateOnDisable)
        {
            target.SetActive(!invert);
        }
    }
}
