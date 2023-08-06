using UnityEngine;

public class PrincessCharacterManager : Singleton<PrincessCharacterManager>
{
    private const int CHARACTER_COUNT = 5;
    
    public GameObject characterObject;
    
    private void Start()
    {
        // todo: 추후 게임 시작시 받아오는 형식으로 변경 
        for (int i = 0; i < CHARACTER_COUNT; i++)
        {
            var character = Instantiate(characterObject);
            character.transform.position = new Vector3(-11 - i * 1.2f, 1f + i % 3 * 0.5f, 0);
        }
    }
}
