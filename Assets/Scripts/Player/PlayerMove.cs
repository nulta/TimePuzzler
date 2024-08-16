using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player moves
/// </summary>
public class PlayerMove : MonoBehaviour
{
    #region Fields

    // move speed
    float MovesPerSecond = 3f;

    #endregion

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += horizontal * Time.deltaTime * MovesPerSecond;
            transform.position = newPosition;
        }
        SendMessage("AnimateMovement", horizontal);

        bool seeFront = (horizontal == 0) && (Input.GetAxisRaw("Vertical") < 0);
        if (seeFront) { SendMessage("AnimateSeeFront"); }
    }

}
