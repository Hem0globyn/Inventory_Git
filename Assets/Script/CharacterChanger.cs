using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChanger : MonoBehaviour
{
    public GameObject elf;
    public GameObject knight;

    public CharacterStatus elfStat;
    public CharacterStatus knightStat;

    [SerializeField] TextMeshProUGUI attack;
    [SerializeField] TextMeshProUGUI defense;
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] TextMeshProUGUI crit;

    private void Start()
    {
        OnKnightStat();
    }

    public void OnElfStat()
    {
        knight.SetActive(false);

        elf.SetActive(true);
        attack.text = elfStat.attack.ToString();
        defense.text = elfStat.defense.ToString();
        hp.text = elfStat.healthPoint.ToString();
        crit.text = (elfStat.critical*100).ToString();
    }
    public void OnKnightStat()
    {
        elf.SetActive(false);

        knight.SetActive(true);
        attack.text = knightStat.attack.ToString();
        defense.text = knightStat.defense.ToString();
        hp.text = knightStat.healthPoint.ToString();
        crit.text = (knightStat.critical * 100).ToString();
    }

    //스텟이 필요하다면 여기서 stat 클래스를 할당해 전해줄 것 (현재는 텍스트만 필요하므로 보류)
}
