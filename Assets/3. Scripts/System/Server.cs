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


