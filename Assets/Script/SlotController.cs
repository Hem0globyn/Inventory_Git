using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public Image icon; // The item that this slot holds
    public Image backGround;
    public ItemBase itemBase;
    public TextMeshProUGUI count;
    public TextMeshProUGUI equipBtnText;
    public GameObject equipBtn;
    public GameObject useBtn;
    public CharacterChanger statChanger;
    public Button equipButton;
    public Button useButton;

    public bool isEquiped;
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
        if (itemBase == null) return; //아이템이 없으면 초기화 안함
        icon.sprite = itemBase.itemIcon; //아이콘 설정
        ResetSelect();  //전체 초기화
        selected = true;
        Selected(); //선택된 슬롯 색상 초기화
        LinkButton(); //버튼 연결
    }


    public void ResetSelect()
    {
        foreach (Transform child in parent)
        {
            SlotController slot = child.GetComponent<SlotController>();
            if (slot == null) continue;

            slot.selected = false;
            slot.backGround.color = defaultColor; //기본 색상으로 초기화
        }
    }

    public void RenewInv()
    {

    }


    private void Selected()
    {
        if(selected)
        {
            backGround.color = new Color(27 / 255f, 1f, 0f, 1f);
            if (itemBase.itemType == ItemType.Equipable)
            {
                equipBtn.SetActive(true);
                useBtn.SetActive(false);
            }
            else if (itemBase.itemType == ItemType.Consumable)
            {
                equipBtn.SetActive(false);
                useBtn.SetActive(true);
            }
            else
            {
                equipBtn.SetActive(false);
                useBtn.SetActive(false);
            }
        }
        else
        {
            return;
        }
    }

    private void LinkButton()
    {
        if(equipBtn.activeSelf) //equip 버튼이 활성화되어 있다면
        {
            equipButton.onClick.RemoveAllListeners(); //기존에 등록된 리스너 제거
            equipButton.onClick.AddListener(OnClickEquipBtn); //equip 버튼 클릭시 OnClickEquipBtn 메소드 호출
        }
        else if(useBtn.activeSelf)  //use 버튼이 활성화되어 있다면
        {
            useButton.onClick.RemoveAllListeners(); //기존에 등록된 리스너 제거
            useButton.onClick.AddListener(OnClickUseBtn); //use 버튼 클릭시 OnClickUseBtn 메소드 호출
        }
    }


    public void OnClickEquipBtn()
    {
        if (itemBase is EquipableItem equip)
        {
            if (isEquiped) //이미 장착되어 있다면
            {
                isEquiped = false;
                StatHandler.Instance.equipAtkStat -= equip.attack; //공격력 감소

                if(StatHandler.Instance.equipAtkStat <= 0) //공격력이 0보다 작아지면
                {
                    TextManager.Instance.ResetStat(TextManager.StatType.Attack); //장착 해제시 공격력 감소
                }
                else
                    TextManager.Instance.AddAttack(StatHandler.Instance.equipAtkStat);

                if(StatHandler.Instance.equipCritStat <= 0) //크리티컬 확률이 0보다 작아지면
                {
                    TextManager.Instance.ResetStat(TextManager.StatType.Critical); //장착 해제시 크리티컬 확률 감소
                }
                else
                    TextManager.Instance.AddCrit(StatHandler.Instance.equipCritStat);



                count.text = "";
            }
            else if (!isEquiped) //장착 안했으면
            { 
                StatHandler.Instance.equipAtkStat += equip.attack; //공격력 증가
                StatHandler.Instance.equipCritStat += equip.crit*100; //크리티컬 확률 증가
                TextManager.Instance.AddAttack(StatHandler.Instance.equipAtkStat); //텍스트 매니저에 공격력 추가
                TextManager.Instance.AddCrit(StatHandler.Instance.equipCritStat); //크리티컬 확률 추가
                count.text = "E";
                isEquiped = true;
            }
        }
    }

    public void OnClickUseBtn()
    {
        if (itemBase is ConsumableItem consumable)
        {
            StatHandler.Instance.expBar.AddExp(consumable.xpGain);
            itemCount--;
            count.text = itemCount.ToString();
            if (itemCount <= 0)
            {
                itemBase = null; //아이템이 없으면 null로 설정
                icon.sprite = null; //아이콘도 비움
                count.text = ""; //카운트 텍스트도 비움
            }
        }
    }


    public void AllReset()
    {
        if(parent == null) return;
        foreach (Transform child in parent)
        {
            SlotController slot = child.GetComponent<SlotController>();
            if (slot == null) continue;

            slot.isEquiped = false; //장착 상태 초기화
            StatHandler.Instance.equipAtkStat = 0; //장착 공격력 초기화
            slot.selected = false;
            slot.backGround.color = defaultColor; //기본 색상으로 초기화
            slot.count.text = ""; //카운트 텍스트 초기화
        }
        if (equipButton != null)
            equipButton.onClick.RemoveAllListeners();

        if (useButton != null)
            useButton.onClick.RemoveAllListeners();
    }
}
