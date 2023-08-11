using System.Collections.Generic;
using UnityEngine;

public class PrincessCharacterManager : Singleton<PrincessCharacterManager>
{
    private const int CHARACTER_COUNT = 5;
    
    public GameObject characterObject;
    public List<PrincessCharacterBattleIcon> characterIcons;
    
    [HideInInspector]
    public List<PrincessCharacter> characters;
    
    private void Start()
    {
        for (int i = 0; i < CHARACTER_COUNT; i++)
        {
            var character = Instantiate(characterObject);
            character.transform.position = new Vector3(-11 - i * 1.2f, i % 3 * 0.5f, 0);

            var princessCharacter = character.GetComponent<PrincessCharacter>();
            princessCharacter.Init(GameSystem.Instance.characterInfoDatas[i], i);
            characters.Add(princessCharacter);
            characterIcons[i].Init(GameSystem.Instance.characterInfoDatas[i]);
            characterIcons[i].InitSlider(princessCharacter);
        }
    }
}
