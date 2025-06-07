using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoSingleton<TextManager>
{
    public TextMeshProUGUI attack;
    public TextMeshProUGUI defense;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI critical;
    public TextMeshProUGUI characterDescription;
    public TextMeshProUGUI itemDescription;

    private string baseAttackText;
    private string baseDefenseText;
    private string baseCritText; //기본 크리티컬 텍스트 저장용
    //다른 스텟은 필요시 추가


    public enum StatType
    {
        Attack,
        Defense,
        Hp,
        Critical
    }
    protected override void Awake()
    {
        base.Awake();

        
        
    }
    public void SetBaseText()
    {
        baseAttackText = attack.text;
        baseDefenseText = defense.text;
        baseCritText = critical.text;
    }


    public void AddAttack(int k)
    {
        string currentText = $"{baseAttackText} + ({k.ToString()})";
        attack.text = currentText;
    }

    public void AddDefence(int k)
    {
        string currentText = $"{baseDefenseText} + ({k.ToString()})";
        defense.text = currentText;
    }

    public void AddCrit(float k)
    {
        string currentText = $"{baseCritText} + ({k.ToString()})";
        critical.text = currentText;
    }




    public void ResetStat(StatType type)
    {
        if(type == StatType.Attack)
        {
            attack.text = baseAttackText;
        }
        else if (type == StatType.Defense)
        {
            defense.text = baseDefenseText;
        }
        else if (type == StatType.Critical)
        {
            critical.text = baseCritText;
        }


        /*  현재 불필요한 부분 게임으로 만들어지면 추가
        defense.text = ;
        hp.text = ; 

        */
    }

    //매서드도 비슷한 형식으로 추가
    //15 + (k) 형식으로 출력
}
