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

    #region UnityMethod

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += horizontal * Time.deltaTime * MovesPerSecond;
            transform.position = newPosition;
        }
    }

    #endregion
}
