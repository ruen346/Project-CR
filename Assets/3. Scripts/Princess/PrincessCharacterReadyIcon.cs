using UnityEngine;

public class PrincessCharacterReadyIcon : PrincessCharacterIcon
{
    public bool isReadyCharacter; // 편성된 캐릭터 인지
    
    private void Start()
    {
        // 연속해서 플레이 가능시 값 받아오도록 수정
        hpSlider.value = 1;
        mpSlider.value = 0;
    }

    public void OnClickIcon()
    {
        if (isReadyCharacter)
        {
            characterInfoData = null;
            isSetData = false;
            characterImage.sprite = Resources.Load<Sprite>("Texture/Character/Icon/DisableCharacterIcon");
        }
        else
        {
            PrincessReadyWindow.Instance.SetUnableCharacter(characterInfoData);
        }
    }
}
