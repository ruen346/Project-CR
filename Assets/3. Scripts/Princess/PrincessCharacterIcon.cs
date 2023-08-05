using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrincessCharacterIcon : MonoBehaviour
{
    public Image characterImage;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI starText;
    public Slider hpSlider;
    public Slider mpSlider;

    public void Init(CharacterInfoData data)
    {
        SetImage(data);
        SetText(data);
    }
    
    private void SetImage(CharacterInfoData data)
    {
        characterImage.sprite = Resources.Load<Sprite>($"Texture/Character/Icon/CharacterIcon{data.id}");
    }

    private void SetText(CharacterInfoData data)
    {
        levelText.text = data.level.ToString();
        starText.text = data.star.ToString();
    }
}
