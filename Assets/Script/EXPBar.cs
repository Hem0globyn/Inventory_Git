using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour
{
    public TextMeshProUGUI expBarText;
    private Image parameter;
    public int currentExp = 0;
    public int maxExp = 12;
    public TextMeshProUGUI levelText;
    public int level = 1; //레벨

    private void Awake()
    {
        parameter = GetComponent<Image>();
    }
    void Start()
    {
        expBarText.text = $"{currentExp} / {maxExp}";
    }

    public void AddExp(int exp)
    {
        currentExp += exp;
        if (currentExp >= maxExp)
        {
            currentExp -= maxExp;
            level++; //레벨업
            LevelUp(); //레벨업 함수 호출
        }
        currentExp = Mathf.Clamp(currentExp, 0, maxExp); //혹시몰라 버그나면 음수뜨니까 넣음
        RenewText();
        parameter.fillAmount = (float)currentExp / maxExp;
    }

    public void LevelUp()
    {
        levelText.text = $"LV {level}"; //레벨 텍스트 갱신
    }



    private void RenewText()
    {
        expBarText.text = $"{currentExp} / {maxExp}";
    }
}
