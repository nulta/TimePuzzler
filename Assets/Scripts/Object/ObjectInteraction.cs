using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object Interaction with Player
/// </summary>
public class ObjectInteraction : MonoBehaviour
{
    #region Fields

    float ScaleIncrease = 1.01f;
    bool isPlayerTouching = false;

    [SerializeField]
    private GameObject GameUI;

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.localScale = Vector3.one * ScaleIncrease;
            isPlayerTouching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.localScale = Vector3.one;
            isPlayerTouching = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerTouching && Input.GetButtonDown("Action"))
        {
            InteractWithObject();
        }
    }

    /// <summary>
    /// wire connect game
    /// </summary>
    private void InteractWithObject()
    {
        if (GameUI != null)
        {
            GameUI.SetActive(true);
        }
    }
}
