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
        nameText.text = $"어둠의 암살자 Lv.{boss.level}";
        hpSlider.maxValue = boss.maxHp;
    }

    private void Update()
    {
        hpSlider.value = boss.hp;
    }
}
