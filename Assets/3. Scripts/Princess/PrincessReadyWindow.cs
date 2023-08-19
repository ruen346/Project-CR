using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrincessReadyWindow : BaseWindow
{
    public static PrincessReadyWindow Instance;
    
    public GameObject characterIcon;
    public GameObject iconContent;
    public List<PrincessCharacterIcon> readyCharacterIcons;

    private void Awake()
    {
        Instance = this;
    }
    
    public void Start()
    {
        foreach (var data in DataManager.Instance.characterData.CharacterInfoDatas)
        {
            if (!data.isGet)
            {
                continue;
            }
            
            var character = Instantiate(characterIcon, iconContent.transform);
            character.GetComponent<PrincessCharacterReadyIcon>().Init(data);
        }
    }

    public void OnClickStartButton()
    {
        if (IsAllCharacterSetting())
        {
            var characters = readyCharacterIcons.Select(character => character.characterInfoData).ToList();
            GameSystem.Instance.SetPrincessCharacter(characters);
        }
        else
        {
            MenuManager.Instance.OpenMessageWindow("편성 오류", "5명의 캐릭터가 모두 편성되지 않았습니다.", true);
        }
    }

    private bool IsAllCharacterSetting()
    {
        foreach (var icon in readyCharacterIcons)
        {
            if (!icon.isSetData)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 캐릭터 편성
    /// </summary>
    /// <param name="data">캐릭터 정보</param>
    public void SetUnableCharacter(CharacterInfoData data)
    {
        // 중복 편성 캐릭터 확인
        foreach (var icon in readyCharacterIcons)
        {
            if (icon.isSetData && icon.characterInfoData == data)
            {
                return;
            }
        }
        
        // 빈공간 서치
        foreach (var icon in readyCharacterIcons)
        {
            if (!icon.isSetData)
            {
                icon.Init(data);
                return;
            }
        }
    }
}
