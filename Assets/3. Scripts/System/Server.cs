using UnityEngine;

public class Server : MonoBehaviour
{
    private const int MAX_CHARACTER_COUNT = 10;
    
    public static string GetUserData()
    {
        var userData = new UserData
        {
            userName = PlayerPrefs.GetString("userName", "모험가"),
            level = PlayerPrefs.GetInt("level", 1),
            exp = PlayerPrefs.GetInt("exp", 0),
            energy = PlayerPrefs.GetInt("energy", 100),
            gold = PlayerPrefs.GetInt("gold", 0),
            dia = PlayerPrefs.GetInt("dia", 0),
        };
        
        return JsonUtility.ToJson(userData);
    }
    
    public static string GetCharacterData()
    {
        var characterData = new CharacterData();

        for (int i = 1; i <= MAX_CHARACTER_COUNT; i++)
        {
            var data = new CharacterInfoData
            {
                id = i,
                isGet = Database.IsDefaultCharacter(i),
                name = Database.GetCharacterName(i),
                level = PlayerPrefs.GetInt($"characterlevel_{i}", 1)
            };
            
            characterData.CharacterInfoDatas.Add(data);
        }
        
        return JsonUtility.ToJson(characterData);
    }
    
    /// <summary>
    /// todo : 추후 다른식으로 구현
    /// </summary>
    /// <param name="expValue"></param>
    /// <returns></returns>
    public static string SetExp(string expValue)
    {
        int level = PlayerPrefs.GetInt("level", 1);
        int exp = PlayerPrefs.GetInt("exp", 0);
        
        exp += int.Parse(expValue);

        if (exp >= DataManager.Instance.GetMaxExp())
        {
            exp -= DataManager.Instance.GetMaxExp();
            level++;
        }
        
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("exp", exp);
        
        var userData = new UserData
        {
            level = level,
            exp = exp,
        };
        
        return JsonUtility.ToJson(userData);
    }
}


