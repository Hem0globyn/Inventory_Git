using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "MyGame/StatData")]
public class CharacterStatus : ScriptableObject
{
    [Header("ATK")]
    public int attack;

    [Header("DEF")]
    public int defense;

    [Header("HP")]
    public int healthPoint;

    [Header("Crit")]
    public float critical;
}
