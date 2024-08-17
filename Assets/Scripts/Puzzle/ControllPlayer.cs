using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPlayer : MonoBehaviour
{
    // if puzzle enabled, restricted
    [SerializeField]
    private PlayerMove playerMove1;
    [SerializeField]
    private PlayerMove playerMove2;
    [SerializeField]
    private TimelineSwitcher timelineSwitcher;

    private void OnEnable()
    {
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
