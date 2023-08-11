using System.Collections.Generic;
using UnityEngine;

public class PrincessReadyWindow : BaseWindow
{
    public static PrincessReadyWindow Instance;
    
    public GameObject characterIcon;
    public GameObject viewport;
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
                break;
            }
            
            var character = Instantiate(characterIcon, viewport.transform);
            character.GetComponent<PrincessCharacterReadyIcon>().Init(data);
        }
    }

    public void OnClickStartButton()
    {
        if (IsAllCharacterSetting())
        {
            MenuManager.Instance.MoveScene("PrincessScene");
        }
        else
        {
            MenuManager.Instance.OpenMessageWindow("편성 오류", "5명의 캐릭터가 모두 편성되지 않았습니다.");
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
