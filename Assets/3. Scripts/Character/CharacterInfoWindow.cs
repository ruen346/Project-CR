using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoWindow : BaseWindow
{
    public Image characterImage;
    public List<Image> starImages;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI hpText;

    private CharacterInfoData characterData;

    public void Init(CharacterInfoData data)
    {
        characterData = data;

        SetImages();
        SetTexts();
    }

    private void SetImages()
    {
        characterImage.sprite = Resources.Load<Sprite>($"Texture/Character/Image/Character{characterData.id}");
        for (int i = 3; i > 0; i--)
        {
            if (characterData.star < i)
            {
                starImages[i - 1].color = Color.gray; 
            }
        }
    }

    private void SetTexts()
    {
        nameText.text = characterData.name;
        levelText.text = $"Lv.{characterData.level}";
        damageText.text = $"공격력 : {characterData.damage}";
        hpText.text = $"채력 : {characterData.hp}";
    }

    public void OnClickUpgradeButton()
    {
        
    }
}
