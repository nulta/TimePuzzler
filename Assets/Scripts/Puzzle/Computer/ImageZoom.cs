using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Hint Image Zoom
/// </summary>
public class ImageZoom : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private Image targetImage;
    private bool isZoomed = false;
    private Vector3 originalScale;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        originalScale = targetImage.transform.localScale;
    }

    public void OnImageClick()
    {
        if (!isZoomed)
        {
            targetImage.transform.localScale = originalScale * 6;
            isZoomed = true;
        }
        else
        {
            targetImage.transform.localScale = originalScale;
            isZoomed = false;
        }
    }
}
