using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour
{
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
        var characterInfoData = new List<CharacterInfoData>();

        for (int i = 1; i <= Database.MAX_CHARACTER_COUNT; i++)
        {
            var data = new CharacterInfoData
            {
                id = i,
                isGet = PlayerPrefs.GetInt($"characterIsGet_{i}", Database.IsDefaultCharacter(i)) == 1,
                name = Database.GetCharacterName(i),
                level = PlayerPrefs.GetInt($"characterlevel_{i}", 1),
                star = PlayerPrefs.GetInt($"characterStar_{i}", Database.IsCharacterStar(i)),
                damage =  Database.GetCharacterDamage(i),
                hp =  Database.GetCharacterHp(i),
                position =  Database.GetCharacterPosition(i)
            };
            
            characterInfoData.Add(data);
        }
        characterData.CharacterInfoDatas = characterInfoData;
        return JsonUtility.ToJson(characterData);
    }
    
    public static string SetExp(string expValue)
    {
        int level = PlayerPrefs.GetInt("level", 1);
        int exp = PlayerPrefs.GetInt("exp", 0);
        int maxExp = Database.GetMaxExp(level);
        
        exp += int.Parse(expValue);

        if (exp >= maxExp)
        {
            exp -= maxExp;
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
    
    public static string PrincessStart()
    {
        var userData = new BossData
        {
            name = PlayerPrefs.GetString("bossName", "어둠의 암살자"),
            level = PlayerPrefs.GetInt("bossLevel", 30),
            hp = PlayerPrefs.GetInt("bossHp", 100000),
            damage = PlayerPrefs.GetInt("bossDamage", 100)
        };
        
        return JsonUtility.ToJson(userData);
    }
    
    public static string PrincessClear()
    {
        const int getExp = 10;
        const int getGold = 1000;
        
        int level = PlayerPrefs.GetInt("level", 1);
        int exp = PlayerPrefs.GetInt("exp", 0) + getExp;
        int maxExp = Database.GetMaxExp(level);
        int gold = PlayerPrefs.GetInt("gold", 0) + getGold;

        if (exp >= maxExp)
        {
            exp -= maxExp;
            level++;
        }
        
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("exp", exp);
        PlayerPrefs.SetInt("gold", gold);
        
        var userData = new UserData
        {
            level = level,
            exp = exp,
            gold = gold
        };

        var princessClearData = new PrincessClearData
        {
            userData = userData,
            getExp = getExp,
            getGold = getGold
        };
        
        return JsonUtility.ToJson(princessClearData);
    }
}


