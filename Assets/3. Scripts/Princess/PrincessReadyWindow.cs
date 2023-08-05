using UnityEngine;

public class PrincessReadyWindow : BaseWindow
{
    public GameObject characterIcon;
    public GameObject viewport;
    
    public void Start()
    {
        foreach (var data in DataManager.Instance.characterData.CharacterInfoDatas)
        {
            var character = Instantiate(characterIcon, viewport.transform);
            character.GetComponent<PrincessCharacterReadyIcon>().Init(data);
        }
    }

    public void OnClickStartButton()
    {
        MenuManager.Instance.MoveScene("PrincessScene");
    }
}
