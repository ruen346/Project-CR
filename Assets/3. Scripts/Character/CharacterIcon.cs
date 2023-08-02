using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIcon : MonoBehaviour
{
    public Image characterImage;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI starText;
    public TextMeshProUGUI nameText;

    public void Init(CharacterInfoData data)
    {
        SetImage(data);
        SetText(data);
    }
    
    private void SetImage(CharacterInfoData data)
    {
        
    }

    private void SetText(CharacterInfoData data)
    {
        levelText.text = data.level.ToString();
        starText.text = data.star.ToString();
        nameText.text = data.name;
    }
    
    /// <summary>
    /// 뽑은거만 보이고 눌리도록 수정 필요
    /// </summary>
    public void OnClickIcon()
    {
        
    }
}
