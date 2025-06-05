using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMediator : MonoSingleton<TextMediator>
{
    public TextMeshProUGUI attack;
    public TextMeshProUGUI defence;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI critical;
    public TextMeshProUGUI xpBar;
    public TextMeshProUGUI characterDescription;
    public TextMeshProUGUI itemDescription;

    protected override void Awake()
    {
        base.Awake();
    }
}
