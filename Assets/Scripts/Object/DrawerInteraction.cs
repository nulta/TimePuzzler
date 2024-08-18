using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Drawer Interaction with Player when Player has key
/// </summary>
public class DrawerInteraction : MonoBehaviour
{
    #region Fields

    float ScaleIncrease = 1.1f;
    bool isPlayerTouching = false;

    [SerializeField]
    private GameObject GameUI;

    private TimelineSwitcher timelineSwitcher;
    private PlayerInteract playerInteract;

    private bool playerHasKey = false;

    #endregion

    private void Start()
    {
        timelineSwitcher = FindAnyObjectByType<TimelineSwitcher>();

        if (timelineSwitcher != null)
        {
            playerInteract = timelineSwitcher.playerFuture.GetComponent<PlayerInteract>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= ScaleIncrease;
            newScale.y *= ScaleIncrease;
            transform.localScale = newScale;
            isPlayerTouching = true;

            if (playerInteract != null)
            {
                playerHasKey = playerInteract.hasKey;
            }
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
        if (isPlayerTouching && Input.GetButtonDown("Action") && playerHasKey)
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

            StartCoroutine(HideUI(2f));
        }
    }

    private IEnumerator HideUI(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameUI.SetActive(false);
    }
}
