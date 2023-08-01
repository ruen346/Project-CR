using System.Collections.Generic;

public class UserData
{
    public string userName;
    public int level;
    public int exp;

    public int energy;
    public int gold;
    public int dia;
}

public class CharacterData
{
    public List<CharacterInfoData> CharacterInfoDatas;
}

public class CharacterInfoData
{
    public int id;
    public bool isGet;
    public string name;
    public int level;
}