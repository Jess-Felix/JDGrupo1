using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowControls : MonoBehaviour
{
    public GameObject panelImage;

    public void ShowImage()
    {
        panelImage.SetActive(true);
    }

    public void HideImage()
    {
        panelImage.SetActive(false);
    }
}
