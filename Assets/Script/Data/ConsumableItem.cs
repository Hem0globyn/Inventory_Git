using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewConsumableItem", menuName = "MyGame/Items/Consumable")]
public class ConsumableItem : ItemBase
{
    public int hpRestore;
    public int staminaRestore;
    public int xpGain;

    private void OnEnable()
    {
        itemType = ItemType.Consumable;
    }
}
