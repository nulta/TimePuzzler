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
    [SerializeField]
    private GameObject goToPastText;
    [SerializeField]
    private GameObject goToFutureText;

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
        if (isPastActive && goToPastText != null)
        {
            goToPastText.SetActive(true);
        }
        else if (!isPastActive && goToFutureText != null) 
        {
            goToFutureText.SetActive(true);
        }
    }
}
