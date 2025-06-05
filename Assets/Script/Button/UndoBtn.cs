using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoBtn : MonoBehaviour
{
    public GameObject thisCanvas;
    public GameObject statusBtn;
    public GameObject invenBtn;
    public void Onclicked()
    {
        thisCanvas.SetActive(false);
        statusBtn.SetActive(true);
        invenBtn.SetActive(true);
    }
}
