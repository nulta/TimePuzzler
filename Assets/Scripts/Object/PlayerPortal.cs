using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Teleports player when interacted
/// </summary>
public class PlayerPortal : MonoBehaviour
{
    #region Fields

    public Vector2 teleportDelta = new Vector2(0, 0);

    GameObject player = null;

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player = null;
        }
    }

    void Update()
    {
        if (player && player.activeInHierarchy && Input.GetButtonDown("Action"))
        {
            InteractWithObject(player);
            player = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        var endPos = (Vector2)transform.position + teleportDelta;
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawLine(transform.position, endPos);
        Gizmos.DrawLine(endPos - new Vector2(0.5f, 0.5f), endPos + new Vector2(0.5f, 0.5f));
        Gizmos.DrawLine(endPos - new Vector2(-0.5f, 0.5f), endPos + new Vector2(-0.5f, 0.5f));
    }


    protected void InteractWithObject(GameObject player)
    {
        player.transform.position += (Vector3)teleportDelta;
    }
}
