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
        if (DataManager.Instance.gold >= 1000)
        {
            CommandManager.Instance.AddCommand("UpgradeCharacter.php", characterData.id.ToString(), ResponseUpgradeData);
        }
        else
        {
            MenuManager.Instance.OpenMessageWindow("골드 부족", "캐릭터 업그레이드에 필요한 골드가 부족합니다.", true);
        }
    }

    private void ResponseUpgradeData(int result, string data)
    {
        if (result == 1)
        {
            var characterUpgradeData = JsonUtility.FromJson<CharacterUpgradeData>(data);
            DataManager.Instance.SetCharacterData(characterUpgradeData);
            
            SetTexts();
            CharacterWindow.instance.UpdateData();
        }
    }

    public void OnClickBackgroundButton()
    {
        PlayerPrefs.SetInt("background", characterData.id);
        BackgroundManager.Instance.SetBackground(characterData.id);
    }
}
