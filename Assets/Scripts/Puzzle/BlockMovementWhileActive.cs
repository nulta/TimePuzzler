using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovementWhileActive : MonoBehaviour
{
    // if puzzle enabled, restricted
    private PlayerMove playerMove1;
    private PlayerMove playerMove2;
    private TimelineSwitcher timelineSwitcher;

    private void OnEnable()
    {
        timelineSwitcher = FindAnyObjectByType<TimelineSwitcher>();
        playerMove1 = timelineSwitcher.playerFuture.GetComponent<PlayerMove>();
        playerMove2 = timelineSwitcher.playerPast.GetComponent<PlayerMove>();

        playerMove1.canMove = false;
        playerMove2.canMove = false;
        timelineSwitcher.canSwitch = false;
    }

    private void OnDisable()
    {
        playerMove1.canMove = true;
        playerMove2.canMove = true;
        timelineSwitcher.canSwitch = true;
    }
}
