using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public Image icon; // The item that this slot holds
    public ItemBase itemBase;
    public Text count;

    private void Awake()
    {
        icon = GetComponentInChildren<Image>();
        count = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        if(itemBase == null)
        {
            return;
        }
        icon.sprite = itemBase.itemIcon;
    }
}
