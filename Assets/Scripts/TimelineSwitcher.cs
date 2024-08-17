using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Timeline switcher: switch the player between the past and future
/// </summary>
public class TimelineSwitcher : MonoBehaviour
{
    public GameObject playerFuture;
    public GameObject playerPast;
    public bool isPastActive = false;
    public bool canSwitch = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && CanSwitch())
        {
            Switch();
        }
    }

    bool CanSwitch()
    {
        return canSwitch;
    }

    void Switch()
    {
        isPastActive = !isPastActive;
        playerFuture.SetActive(!isPastActive);
        playerPast.SetActive(isPastActive);
    }
}
