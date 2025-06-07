using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    //트랜스폼 가져와서 foreach 쓸 준비
    [SerializeField]Transform slotGrid;
    [SerializeField]ItemBase xpHeart;
    SlotController slotController;
    public void OnClickAddButton()
    {
        //버튼 클릭시 
        //foreach문으로 순회하면서 빈자리 찾기(itembase ==null)
        //널인데다가 데이터 넣어주고 슬롯 컨트롤러에서 갱신
        //카운트 올려주고 5개 되면 fullstack bool값 반환해서 다른 슬롯 찾게    
        //로직 분리해서 어이템 추가 / 개수추가 따로 하기?x
        //순회하면서 조건을 더걸기
        //usable && !isfullstack
        //이거 인터페이스로 만들어서 확장성 넓히기 가능
        //확장할때 어이템 정보 칸 넣어주고 그거랑 비교할 수 있게 설계
        //아이템 정보 
        //EquipableItem greatSword =     
        //   Resources.Load<EquipableItem>("Items
        //   /GreatSword");
        //   this.itemBase = greatSword;
        // 이렇게 데이터 받아올 수 있음

        foreach(Transform slotData in slotGrid)
        {
            slotController = slotData.GetComponent<SlotController>();
            if(slotController.itemBase == null) //슬롯에 아이템이 없다면
            {
                //아이템 데이터 넣어주고
                slotController.itemBase = xpHeart;
                slotController.itemCount = 1;
                slotController.ResetSlot(); //슬롯 초기화
                return; //빈 슬롯에 넣었으니 종료
            }
            if(slotController.itemBase.itemType == ItemType.Consumable && slotController.itemCount < 5) //소모품이고 개수가 5개 미만이라면
            {
                slotController.itemCount++; //개수 올려주고
                slotController.Counter(); //카운터 갱신
                return; //개수 올렸으니 종료
            }
        }
    }







}
