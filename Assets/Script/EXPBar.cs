using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EXPBar : MonoBehaviour
{
    public TextMeshProUGUI expBarText;
    private Image parameter;
    public int currentExp = 0;
    public int maxExp = 12;

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
        currentExp = Mathf.Clamp(currentExp, 0, maxExp); //최대치 제한

        if (currentExp == maxExp)
            currentExp -= maxExp;
        currentExp = Mathf.Clamp(currentExp, 0, maxExp); //혹시몰라 버그나면 음수뜨니까 넣음
        parameter.fillAmount = (float)currentExp / maxExp;
    }
}
