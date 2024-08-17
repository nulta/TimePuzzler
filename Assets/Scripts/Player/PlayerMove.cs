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

    float moveVel = 0f;

    Rigidbody2D rb;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        moveVel = horizontal * MovesPerSecond;
        SendMessage("AnimateMovement", horizontal);

        bool seeFront = (horizontal == 0) && (Input.GetAxisRaw("Vertical") < 0);
        if (seeFront) { SendMessage("AnimateSeeFront"); }
    }

    void FixedUpdate()
    {
        var posDelta = moveVel * Time.fixedDeltaTime * Vector2.right;
        rb.MovePosition(rb.position + posDelta);
    }

}
