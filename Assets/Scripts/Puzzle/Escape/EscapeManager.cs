using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Escape Manager
/// </summary>
public class EscapeManager : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private TextMeshProUGUI[] inputNumber;
    [SerializeField]
    private Button escapeButton;
    [SerializeField]
    private GameObject errorText;

    private int[] correctAnswers = { 7, 4, 3 };

    [SerializeField]
    private GameObject openFuturePortal;
    [SerializeField]
    private GameObject openPastPortal;
    [SerializeField]
    private GameObject escapeObject;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (escapeButton != null)
        {
            escapeButton.onClick.AddListener(() => CheckAnswer());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    private void CheckAnswer()
    {
        for (int i = 0; i < correctAnswers.Length; i++)
        {
            if (correctAnswers[i] != int.Parse(inputNumber[i].text))
            {
                ShowError();
                return;
            }
        }
        EscapeSuccess();
    }

    private void EscapeSuccess()
    {
        Debug.Log("Escape Successly");
        if (openFuturePortal != null && openPastPortal != null)
        {
            openFuturePortal.SetActive(true);
            openPastPortal.SetActive(true);
        }
        if (escapeObject != null)
        {
            escapeObject.SetActive(false);
        }

        Close();
    }

    private void ShowError()
    {
        if (errorText != null)
        {
            errorText.SetActive(true);
        }
        Close();
    }

    //private IEnumerator HideError(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    errorText.gameObject.SetActive(false);
    //    Close();
    //}

    public void Close()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
