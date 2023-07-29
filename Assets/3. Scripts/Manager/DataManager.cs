using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    public string userName { get; private set; }
    public int level { get; private set; }
    public int exp { get; private set; }
    public int energy { get; private set; }
    public int gold { get; private set; }
    public int dia { get; private set; }
    
    private void Awake()
    {
        GetUserData();
    }

    private void GetUserData()
    {
        var jsonData = CommandManager.Instance.AddCommand("GetUserData.php");
        var userData = JsonUtility.FromJson<UserData>(jsonData);

        userName = userData.userName;
        level = userData.level;
        exp = userData.exp;
        energy = userData.energy;
        gold = userData.gold;
        dia = userData.dia;
    }
    
    public void SetExp(int value)
    {
        string data = $"{value.ToString()}";
        var jsonData = CommandManager.Instance.AddCommand("SetExp.php", data);
        var userData = JsonUtility.FromJson<UserData>(jsonData);

        level = userData.level;
        exp = userData.exp;
    }
    
    public int GetMaxExp()
    {
        return 100 + level * 20;
    }
}
