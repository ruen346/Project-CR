using UnityEngine;

public class DataManager : DontDestroySingleton<DataManager>
{
    public string userName { get; private set; }
    public int level { get; private set; }
    public int exp { get; private set; }
    public int energy { get; private set; }
    public int gold { get; private set; }
    public int dia { get; private set; }
    
    public CharacterData characterData { get; private set; }
    
    private void Awake()
    {
        GetUserData();
        GetCharacterData();
    }

    private void GetUserData()
    {
        CommandManager.Instance.AddCommand("GetUserData.php", "", ResponseUserData);
    }
    
    private void ResponseUserData(int result, string data)
    {
        if (result == 1)
        {
            var userData = JsonUtility.FromJson<UserData>(data);

            userName = userData.userName;
            level = userData.level;
            exp = userData.exp;
            energy = userData.energy;
            gold = userData.gold;
            dia = userData.dia;
        }
    } 
    
    private void GetCharacterData()
    {
        CommandManager.Instance.AddCommand("GetCharacterData.php", "", ResponseCharacterData);
    }
    
    private void ResponseCharacterData(int result, string data)
    {
        if (result == 1)
        {
            characterData = JsonUtility.FromJson<CharacterData>(data);
        }
    } 
    
    public void SetExp(int value)
    {
        string data = $"{value.ToString()}";
        CommandManager.Instance.AddCommand("SetExp.php", data, ResponseExpData);
    }
    
    private void ResponseExpData(int result, string data)
    {
        if (result == 1)
        {
            var userData = JsonUtility.FromJson<UserData>(data);
            level = userData.level;
            exp = userData.exp;
        }
    } 
    
    public int GetMaxExp()
    {
        return 100 + level * 20;
    }

    public void SetEnergy(int energyValue)
    {
        energy = energyValue;
    }

    public void SetPrincessClearData(UserData userData)
    {
        level = userData.level;
        exp = userData.exp;
        gold = userData.gold;
    }

    public void SetCharacterData(CharacterUpgradeData data)
    {
        foreach (var characterInfo in characterData.CharacterInfoDatas)
        {
            if (characterInfo.id == data.characterInfoData.id)
            {
                characterInfo.level = data.characterInfoData.level;
                characterInfo.damage = data.characterInfoData.damage;
                characterInfo.hp = data.characterInfoData.hp;
                
                break;
            }
        }

        gold = data.userData.gold;
    }
}
