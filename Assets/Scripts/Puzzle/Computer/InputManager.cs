using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Number Input Manager in Computer
/// </summary>
public class InputManager : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    private Button submitButton;
    [SerializeField]
    private GameObject errorText;
    [SerializeField]
    private Image wallPaper;
    [SerializeField]
    private GameObject hintObject;

    string correctDate = "0413";
    int wrongCount = 0;


    #endregion

    private void OnEnable()
    {
        if (inputField != null)
        {
            inputField.Select();
            inputField.ActivateInputField();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
        errorText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnSubmit();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    private void OnSubmit()
    {
        string input = inputField.text;

        if (input == correctDate)
        {
            ShowDesktop();
        }
        else
        {
            inputField.text = string.Empty;
            ShowError();
        }

    }

    private void ShowError()
    {
        if (errorText != null)
        {
            errorText.SetActive(true);
        }

        wrongCount++;
        if (wrongCount >= 3)
        {
            hintObject.SetActive(true);
        }
    }

    private void ShowDesktop()
    {
        Debug.Log("Correct Answer");
        gameObject.SetActive(false);
        wallPaper.gameObject.SetActive(true);
    }

    public void Close()
    {
        if (errorText.gameObject.activeInHierarchy)
        {
            errorText.gameObject.SetActive(false);
        }
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}