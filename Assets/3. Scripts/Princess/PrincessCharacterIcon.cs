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

    private CharacterInfoData characterInfoData;

    public void Init(CharacterInfoData data)
    {
        characterInfoData = data;
        
        SetImage();
        SetText();
    }
    
    private void SetImage()
    {
        characterImage.sprite = Resources.Load<Sprite>($"Texture/Character/Icon/CharacterIcon{characterInfoData.id}");
    }

    private void SetText()
    {
        levelText.text = characterInfoData.level.ToString();
        starText.text = characterInfoData.star.ToString();
    }
}
