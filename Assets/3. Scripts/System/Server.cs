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
            int level = PlayerPrefs.GetInt($"characterLevel_{i}", 1);
            
            var data = new CharacterInfoData
            {
                id = i,
                isGet = PlayerPrefs.GetInt($"characterIsGet_{i}", Database.IsDefaultCharacter(i)) == 1,
                name = Database.GetCharacterName(i),
                level = level,
                star = PlayerPrefs.GetInt($"characterStar_{i}", Database.IsCharacterStar(i)),
                damage = Database.GetCharacterDamage(i) * level,
                hp = Database.GetCharacterHp(i) * level,
                position = Database.GetCharacterPosition(i)
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
        int energy = PlayerPrefs.GetInt("energy", 100) - 10;
        PlayerPrefs.SetInt("energy", energy);
        
        var userData = new UserData
        {
            energy = energy
        };
        
        var bossData = new BossData
        {
            name = PlayerPrefs.GetString("bossName", "어둠의 암살자"),
            level = PlayerPrefs.GetInt("bossLevel", 30),
            hp = PlayerPrefs.GetInt("bossHp", 100000),
            damage = PlayerPrefs.GetInt("bossDamage", 100)
        };

        var princessStartData = new PrincessStartData
        {
            userData = userData,
            bossData = bossData
        };
        
        return JsonUtility.ToJson(princessStartData);
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
    
    public static string UpgradeCharacter(string id)
    {
        int intId = int.Parse(id);
        int gold = PlayerPrefs.GetInt("gold", 0) - 1000; 
        int level = PlayerPrefs.GetInt($"characterLevel_{id}", 1) + 1;

        PlayerPrefs.SetInt($"characterLevel_{id}", level);
        PlayerPrefs.SetInt("gold", gold);
        
        var characterInfoData = new CharacterInfoData
        {
            id = intId,
            level = level,
            damage = Database.GetCharacterDamage(intId) * level,
            hp = Database.GetCharacterHp(intId) * level,
        };
        
        var userData = new UserData
        {
            gold = gold
        };
        
        var characterUpgradeData = new CharacterUpgradeData
        {
            characterInfoData = characterInfoData,
            userData = userData
        };
        
        return JsonUtility.ToJson(characterUpgradeData);
    }
}


