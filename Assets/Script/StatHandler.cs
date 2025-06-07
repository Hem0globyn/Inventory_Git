using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoSingleton<StatHandler>
{
    public EXPBar expBar;
    public int equipAtkStat; //장착된 아이템의 공격력
    public float equipCritStat; //장착된 아이템의 크리티컬 확률

}
