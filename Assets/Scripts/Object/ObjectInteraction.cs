using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object Interaction with Player
/// </summary>
public class ObjectInteraction : MonoBehaviour
{
    #region Fields

    float ScaleIncrease = 1.1f;
    bool isPlayerTouching = false;

    [SerializeField]
    private GameObject GameUI;

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= ScaleIncrease;
            newScale.y *= ScaleIncrease;
            transform.localScale = newScale;
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
        if (isPlayerTouching && Input.GetKeyDown(KeyCode.Space))
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