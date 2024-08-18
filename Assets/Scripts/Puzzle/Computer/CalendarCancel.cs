using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Calendar UI deactivate
/// </summary>
public class CalendarCancel : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action") || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
}
