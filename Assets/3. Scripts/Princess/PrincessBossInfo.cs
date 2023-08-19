using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrincessBossInfo : MonoBehaviour
{
    public Slider hpSlider;
    public TextMeshProUGUI nameText;
    
    public PrincessBoss boss;

    private void Start()
    {
        nameText.text = $"{boss.name} Lv.{boss.level}";
        hpSlider.maxValue = boss.maxHp;
    }

    private void Update()
    {
        hpSlider.value = boss.hp;
    }
}
