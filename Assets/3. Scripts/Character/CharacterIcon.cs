using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIcon : MonoBehaviour
{
    public Image characterImage;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI starText;
    public TextMeshProUGUI nameText;
    public Button button;
    public GameObject infoObject;
    
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

        if (!characterInfoData.isGet)
        {
            characterImage.color = Color.gray;
            button.enabled = false;
            infoObject.SetActive(false);
        }
    }

    private void SetText()
    {
        levelText.text = $"Lv.{characterInfoData.level.ToString()}";
        starText.text = characterInfoData.star.ToString();
        nameText.text = characterInfoData.name;
    }
    
    /// <summary>
    /// 뽑은거만 보이고 눌리도록 수정 필요
    /// </summary>
    public void OnClickIcon()
    {
        var window = MenuManager.Instance.OpenWindow("CharacterInfoWindow");
        window.GetComponent<CharacterInfoWindow>().Init(characterInfoData);
    }
}
