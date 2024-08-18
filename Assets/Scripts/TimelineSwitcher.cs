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
    private GameObject goToPastText = null;
    [SerializeField]
    private GameObject goToFutureText = null;

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
        if (isPastActive)
        {
            SwitchToFuture();
        }
        else
        {
            SwitchToPast();
        }
    }

    public void SwitchToFuture() {
        if (!isPastActive) { return; }
        isPastActive = false;
        playerFuture.SetActive(true);
        playerPast.SetActive(false);

        if (GetPlayerZone(playerFuture) == GetPlayerZone(playerPast))
        {
            var newPos = playerFuture.transform.position;
            newPos.x = playerPast.transform.position.x;
            playerFuture.transform.position = newPos;
            playerFuture.BroadcastMessage("ResetCameraTracking");

            var anim1 = playerPast.GetComponent<PlayerAnimate>();
            var anim2 = playerFuture.GetComponent<PlayerAnimate>();
            anim2.AnimateSetDirection(anim1.GetDirection());
        }

        if (goToPastText != null)
        {
            goToPastText.SetActive(false);
        }

        if (goToFutureText != null)
        {
            goToFutureText.SetActive(true);
        }
    }

    public void SwitchToPast() {
        if (isPastActive) { return; }
        isPastActive = true;
        playerFuture.SetActive(false);
        playerPast.SetActive(true);

        if (GetPlayerZone(playerFuture) == GetPlayerZone(playerPast))
        {
            var newPos = playerPast.transform.position;
            newPos.x = playerFuture.transform.position.x;
            playerPast.transform.position = newPos;
            playerPast.BroadcastMessage("ResetCameraTracking");

            var anim1 = playerFuture.GetComponent<PlayerAnimate>();
            var anim2 = playerPast.GetComponent<PlayerAnimate>();
            anim2.AnimateSetDirection(anim1.GetDirection());
        }

        if (goToPastText != null)
        {
            goToPastText.SetActive(true);
        }

        if (goToFutureText != null)
        {
            goToFutureText.SetActive(false);
        }
    }

    int GetPlayerZone(GameObject player)
    {
        var x = player.transform.position.x;
        var zone = (x + 10) / 30;
        Debug.Log(player);
        Debug.Log(zone);
        return (int) zone;
    }
}
