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

    public bool canMove = true;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove) {
            moveVel = 0;
            SendMessage("AnimateMovement", (object) 0.0f);
            return;
        }

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

    public void SetXPosition(float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
