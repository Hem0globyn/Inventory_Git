using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConsumableItem", menuName = "MyGame/Items/Equipable")]

public class EquipableItem : ItemBase
{
    public int attack;
    public int defense;
    public float crit;
    private void OnEnable()
    {
        itemType = ItemType.Equipable;
    }
}
