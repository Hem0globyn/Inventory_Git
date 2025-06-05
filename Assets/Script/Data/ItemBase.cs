using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable,
    Miscellaneous
}


[CreateAssetMenu(fileName = "NewData", menuName = "MyGame/ItemData")]

public class ItemBase : ScriptableObject
{
    [Header("Item Name")]
    public string itemName;
    [Header("Item Description")]
    public string itemDescription;
    [Header("Item Icon")]
    public Sprite itemIcon;
    [Header("Item Type")]
    public ItemType itemType;
    [Header("Item Value")]
    public int itemValue;
}
