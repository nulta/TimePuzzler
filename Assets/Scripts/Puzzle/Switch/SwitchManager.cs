using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// switch management
/// </summary>
public class SwitchManager : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private Button[] switches;

    private int[] correctAnswers = { 1, 0, 1, 0, 1, 0, 1, 0 };
    private int[] playerAnswers;

    [SerializeField]
    private GameObject openFuturePortal;
    [SerializeField]
    private GameObject openPastPortal;
    [SerializeField]
    private GameObject switchObject;

    #endregion

    readonly Color offColor = new Color(0.19f, 0.58f, 0.19f, 1f);
    readonly Color onColor = new Color(1f, 0.22f, 0.36f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        playerAnswers = new int[switches.Length];

        for (int i = 0; i < switches.Length; i++)
        {
            int index = i;
            switches[i].onClick.AddListener(() => ToggleSwitch(index));
            UpdateButtonAppearance(switches[i], 0);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    // when button clicked
    private void ToggleSwitch(int index)
    {
        playerAnswers[index] = playerAnswers[index] == 1 ? 0 : 1;
        UpdateButtonAppearance(switches[index], playerAnswers[index]);

        CheckAnswers();
    }

    // button's color changed
    private void UpdateButtonAppearance(Button button, int state)
    {
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.color = state == 0 ? Color.green : Color.red;
        }
    }

    // check answer
    private void CheckAnswers()
    {
        for (int i = 0; i < playerAnswers.Length; i++)
        {
            if (playerAnswers[i] == correctAnswers[i])
            {
                return;
            }
        }

        ShowSuccessMessage();
    }

    // when switch success
    private void ShowSuccessMessage()
    {
        Debug.Log("Success");
        if(openFuturePortal != null && openPastPortal != null) 
        {
            openFuturePortal.SetActive(true);
            openPastPortal.SetActive(true);
        }
        if(switchObject != null) 
        {
            switchObject.SetActive(false);
        }

        Close();
    }

    public void Close()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
