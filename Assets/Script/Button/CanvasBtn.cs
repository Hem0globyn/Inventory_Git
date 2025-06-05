using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBtn : MonoBehaviour
{
    public GameObject targetCanvas;
    public GameObject statusBtn;
    public GameObject invenBtn;
    public void Onclicked()
    {
        targetCanvas.SetActive(true);
        statusBtn.SetActive(false);
        invenBtn.SetActive(false);
    }
}
