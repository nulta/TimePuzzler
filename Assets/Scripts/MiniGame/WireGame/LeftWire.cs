using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Left Wire Control
/// </summary>
public class LeftWire : MonoBehaviour
{
    [SerializeField]
    private RectTransform mWireBody;

    private LeftWire mSelectedWire;

    private Canvas mGameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        mGameCanvas = FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTarget(Vector3 targetPosition, float offset)
    {
        float angle = Vector2.SignedAngle(transform.position + Vector3.right - transform.position,
                targetPosition - transform.position);
        float distance = Vector2.Distance(mWireBody.transform.position, targetPosition) - offset;
        mWireBody.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        mWireBody.sizeDelta = new Vector2(distance * (1 / mGameCanvas.transform.localScale.x), mWireBody.sizeDelta.y);
    }

    public void ResetTarget()
    {
        mWireBody.localRotation = Quaternion.Euler(Vector3.zero);
        mWireBody.sizeDelta = new Vector2(0f, mWireBody.sizeDelta.y);
    }
}
