using System.Collections.Generic;

[System.Serializable]
public class UserData
{
    public string userName;
    public int level;
    public int exp;

    public int energy;
    public int gold;
    public int dia;
}

[System.Serializable]
public class CharacterData
{
    public List<CharacterInfoData> CharacterInfoDatas;
}

[System.Serializable]
public class CharacterInfoData
{
    public int id;
    public bool isGet;
    public string name;
    public int level;
    public int star;
    public int damage;
    public int hp;
    public int position; // 위치값 (0 : 전방, 1 : 후방, 2 : 후방 지원)
}

[System.Serializable]
public class BossData
{
    public int hp;
    public int level;
    public int damage;
    public string name;
}

[System.Serializable]
public class PrincessStartData
{
    public UserData userData;
    public BossData bossData;
}

[System.Serializable]
public class PrincessClearData
{
    public UserData userData;
    public int getGold;
    public int getExp;
}

[System.Serializable]
public class CharacterUpgradeData
{
    public CharacterInfoData characterInfoData;
    public UserData userData;
}