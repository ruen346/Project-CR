using UnityEngine;

public class Database : MonoBehaviour
{
    public const int MAX_CHARACTER_COUNT = 10;
    
    public static int IsDefaultCharacter(int id)
    {
        return id <= 6 ? 1 : 0;
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
    
    public static int IsCharacterStar(int id)
    {
        switch (id)
        {
            case 1: 
            case 2: 
            case 3: 
            case 4: 
            case 5: 
                return 1;
            case 6: 
            case 7: 
            case 8:
                return 2;
            case 9: 
            case 10:
                return 3;
            default: 
                return 0;
        }
    }
}
