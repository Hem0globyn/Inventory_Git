using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UIManager : MonoBehaviour
{
    public GameObject statusBtn;
    public GameObject invenBtn;
    public GameObject statusCanvas;
    public GameObject invenCanvas;
    public CharacterChanger characterChanger;

    private void Awake()
    {
        characterChanger.OnKnightStat();
    }

    public void OnclickedStatusBtn()
    {
        statusCanvas.SetActive(true);
        statusBtn.SetActive(false);
        invenBtn.SetActive(false);
    }

    public void OnclickedInvenBtn()
    {
        invenCanvas.SetActive(true);
        statusBtn.SetActive(false);
        invenBtn.SetActive(false);
    }

    public void Undo()
    {
        invenCanvas.SetActive(false);
        statusCanvas.SetActive(false);
        statusBtn.SetActive(true);
        invenBtn.SetActive(true);
    }
}
