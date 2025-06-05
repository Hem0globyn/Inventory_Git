using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public Image icon; // The item that this slot holds
    public Image backGround;
    public ItemBase itemBase;
    public TextMeshProUGUI count;
    public GameObject EquipBtn;
    public GameObject UseBtn;

    public bool selected;
    public Color defaultColor;
    Transform parent;


    public int itemCount;

    private void Awake()
    {
        count = GetComponentInChildren<TextMeshProUGUI>();
        backGround = GetComponent<Image>();
        defaultColor = backGround.color;    //기본색 노란색
        parent = transform.parent; // 부모 오브젝트를 가져옴

    }

    private void Start()
    {
        if(itemBase == null)
        {
            return;
        }
        icon.sprite = itemBase.itemIcon;
    }

    public void Counter()
    {
        if (itemCount >= 1)
        {
            count.text = itemCount.ToString();
        }
        else
        {
            count.text = "";
        }

        if (itemCount >= 0)
        {
            this.itemBase = null;
        }
    }

    public void ResetSlot()
    {
        ResetSelect();  //전체 초기화
        selected = true;
        Selected(); //선택된 슬롯 색상 초기화
    }


    private void ResetSelect()
    {
        foreach (Transform child in parent)
        {
            SlotController slot = child.GetComponent<SlotController>();
            if (slot == null) continue;

            slot.selected = false;
            slot.backGround.color = defaultColor; //기본 색상으로 초기화
        }
    }




    private void Selected()
    {
        if(selected)
        {
            backGround.color = new Color(27 / 255f, 1f, 0f, 1f);
            if (itemBase.itemType == ItemType.Equipable)
            {
                EquipBtn.SetActive(true);
                UseBtn.SetActive(false);
            }
            else if (itemBase.itemType == ItemType.Consumable)
            {
                EquipBtn.SetActive(false);
                UseBtn.SetActive(true);
            }
            else
            {
                EquipBtn.SetActive(false);
                UseBtn.SetActive(false);
            }
        }
        else
        {
            return;
        }
    }
}
