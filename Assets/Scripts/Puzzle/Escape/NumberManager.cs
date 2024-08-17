using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Number controll by button
/// </summary>
public class NumberManager : MonoBehaviour
{
    [SerializeField]
    private Button upButton;
    [SerializeField]
    private Button downButton;
    [SerializeField]
    private TextMeshProUGUI textNumber;

    private int currentNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        if (upButton != null && downButton != null)
        {
            upButton.onClick.AddListener(() => NumberUp());
            downButton.onClick.AddListener(() => NumberDown());
        }

        UpdateNumberDisplay();
    }

    private void NumberUp()
    {
        currentNumber++;
        if (currentNumber > 9)
        {
            currentNumber = 1;
        }
        UpdateNumberDisplay();
    }

    private void NumberDown()
    {
        currentNumber--;
        if (currentNumber < 1) 
        {
            currentNumber = 9;
        }
        UpdateNumberDisplay();
    }

    private void UpdateNumberDisplay()
    {
        textNumber.text = currentNumber.ToString();
    }
}
