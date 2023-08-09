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

    [HideInInspector]
    public CharacterInfoData characterInfoData;
    [HideInInspector]
    public bool isSetData;

    public void Init(CharacterInfoData data)
    {
        characterInfoData = data;
        isSetData = true;
        
        SetImage();
        SetText();
    }
    
    private void SetImage()
    {
        characterImage.sprite = Resources.Load<Sprite>($"Texture/Character/Icon/CharacterIcon{characterInfoData.id}");
    }

    private void SetText()
    {
        levelText.text = $"Lv.{characterInfoData.level.ToString()}";
        starText.text = characterInfoData.star.ToString();
    }
}
