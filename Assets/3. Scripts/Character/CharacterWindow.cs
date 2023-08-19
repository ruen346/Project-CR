using UnityEngine;

public class CharacterWindow : BaseWindow
{
    public GameObject characterIcon;
    public GameObject characterParent;
    
    public void Start()
    {
        foreach (var data in DataManager.Instance.characterData.CharacterInfoDatas)
        {
            var character = Instantiate(characterIcon, characterParent.transform);
            character.GetComponent<CharacterIcon>().Init(data);
        }
    }
}
