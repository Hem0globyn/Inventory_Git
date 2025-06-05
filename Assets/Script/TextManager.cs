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

    public string baseAttackText;
    public string baseDefenseText;
    //다른 스텟은 필요시 추가


    protected override void Awake()
    {
        base.Awake();

        
        
    }
    public void SetBaseText()
    {
        baseAttackText = attack.text;
        baseDefenseText = defense.text;
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


    public void ResetStat()
    {
        attack.text = baseAttackText;
        defense.text = baseDefenseText;
        /*  현재 불필요한 부분 게임으로 만들어지면 추가
        hp.text = ; 
        critical.text = ; 
        */
    }

    //매서드도 비슷한 형식으로 추가
    //15 + (k) 형식으로 출력
}
