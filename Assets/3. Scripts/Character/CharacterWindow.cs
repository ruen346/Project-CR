using UnityEngine;

public class CharacterWindow : BaseWindow
{
    public GameObject characterIcon;
    public GameObject viewport;
    
    public void Start()
    {
        foreach (var data in DataManager.Instance.characterData.CharacterInfoDatas)
        {
            var character = Instantiate(characterIcon, viewport.transform);
            character.GetComponent<CharacterIcon>().Init(data);
        }
    }
}
