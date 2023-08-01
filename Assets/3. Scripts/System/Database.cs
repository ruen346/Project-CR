using UnityEngine;

public class Database : MonoBehaviour
{
    public static bool IsDefaultCharacter(int id)
    {
        return id <= 6;
    }
    
    public static string GetCharacterName(int id)
    {
        switch (id)
        {
            case 1: return "캐릭터1";
            case 2: return "캐릭터2";
            case 3: return "캐릭터3";
            case 4: return "캐릭터4";
            case 5: return "캐릭터5";
            case 6: return "캐릭터6";
            case 7: return "캐릭터7";
            case 8: return "캐릭터8";
            case 9: return "캐릭터9";
            case 10: return "캐릭터10";
            default: return "";
        }
    }
}
