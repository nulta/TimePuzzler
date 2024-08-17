using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wiring Task Left & Right
/// </summary>
public class FixWiringTask : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private List<LeftWire> mLeftWires;

    [SerializeField]
    private List<RightWire> mRightWires;

    [SerializeField]
    private List<int> mCorrectConnections;

    private LeftWire mSelectedWire;

    private bool[] mIsConnected;

    private int[] mConnections;

    #endregion

    private void OnEnable()
    {
        for(int i = 0; i < mLeftWires.Count;i++)
        {
            mLeftWires[i].ResetTarget();
            mIsConnected[i] = false;
            mConnections[i] = 0;
        }
    }

    private void Start()
    {
        mIsConnected = new bool[mLeftWires.Count];
        mConnections = new int[mLeftWires.Count];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.right, 1f);
            if (hit.collider != null)
            {
                var left = hit.collider.GetComponentInParent<LeftWire>();
                if (left != null)
                {
                    mSelectedWire = left;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (mSelectedWire != null)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(Input.mousePosition, Vector2.right, 1f);
                foreach (var hit in hits)
                {
                    if (hit.collider != null)
                    {
                        var right = hit.collider.GetComponentInParent<RightWire>();
                        if (right != null)
                        {
                            int rightIndex = mRightWires.IndexOf(right);
                            mSelectedWire.SetTarget(hit.transform.position, 70f);
                            CheckConnection(mSelectedWire, rightIndex);
                            mSelectedWire = null;
                            return;
                        }
                    }
                }

                mSelectedWire.ResetTarget();
                mSelectedWire = null;
            }
        }

        if (mSelectedWire != null)
        {
            mSelectedWire.SetTarget(Input.mousePosition, 15f);
        }
    }

    private void CheckConnection(LeftWire leftWire, int rightWireIndex)
    {
        int leftIndex = mLeftWires.IndexOf(leftWire);
        Debug.Log($"���� ���� {leftIndex}�� ������ ������ ����Ǿ����ϴ�.");
        mIsConnected[leftIndex] = true;
        mConnections[leftIndex] = rightWireIndex;
        CheckAllConnections();
    }

    private void CheckAllConnections()
    {
        bool allConnected = true;

        for (int i = 0; i < mIsConnected.Length; i++)
        {
            if (!mIsConnected[i])
            {
                allConnected = false;
                break;
            }
        }

        if (allConnected)
        {
            Debug.Log("��� ���� ����. ���� Ȯ��");
            PerformFinalCheck();
        }
    }

    private void PerformFinalCheck()
    {
        for (int i = 0; i < mLeftWires.Count;i++)
        {
            if (mCorrectConnections[i] != mConnections[i])
            {
                Debug.Log($"���� ���� {i}�� �ùٸ��� ������� �ʾҽ��ϴ�.");
                Close();
                return;
            }
        }
        Debug.Log("��� ������ �ùٸ��� ����Ǿ����ϴ�.");
        Close();
    }

    public void Open()
    {
        gameObject.transform.parent.gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
