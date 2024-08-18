using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Key UI Controller
/// </summary>
public class KeyUIController : MonoBehaviour
{
    private TimelineSwitcher timelineSwitcher;
    private PlayerInteract playerInteract;

    [SerializeField]
    private GameObject keyObject;

    private void OnEnable()
    {
        timelineSwitcher = FindAnyObjectByType<TimelineSwitcher>();

        if (timelineSwitcher != null)
        {
            playerInteract = timelineSwitcher.playerFuture.GetComponent<PlayerInteract>();

            if (playerInteract != null )
            {
                playerInteract.hasKey = true;
                Debug.Log("Player get Key");
                if (keyObject != null)
                {
                    keyObject.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Player's Key Error");
            }
        }

        StartCoroutine(HideUI(2f));
    }

    private IEnumerator HideUI(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

}
