using System.Collections.Generic;
using UnityEngine;

public class PrincessCharacterGroup : MonoBehaviour
{
    public List<PrincessCharacterBattleIcon> characterIcons;
    
    private void Start()
    {
        // todo: 임시 데이터
        int dummyIndex = 0;
        
        foreach (var icon in characterIcons)
        {
            // todo: 임시 데이터
            var data = DataManager.Instance.characterData.CharacterInfoDatas[dummyIndex];
            dummyIndex++;
            
            icon.Init(data);
        }
    }

    public void OnSkill(int id)
    {
        
    }
}
