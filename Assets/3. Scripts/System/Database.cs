using UnityEngine;

/// <summary>
/// 가상의 데이터베이스로 서버에 해당 값들이 세팅되어 있다고 가정
/// 따라서 변경되지 않는 해당 값들은 다른 파일로 부터 변환하는 형태가 아닌 원시적으로 정의
/// </summary>
public class Database : MonoBehaviour
{
    public const int MAX_CHARACTER_COUNT = 10;
    
    public static int IsDefaultCharacter(int id)
    {
        return id <= 6 ? 1 : 0;
    }
    
    public static string GetCharacterName(int id)
    {
        // 추후 이름 수정
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
    
    public static int GetCharacterDamage(int id)
    {
        // 추후 값 밸렁싱 수정
        switch (id)
        {
            case 1: 
            case 2: 
            case 3: 
            case 4: 
            case 5: 
                return 10;
            case 6: 
            case 7: 
            case 8:
            case 9: 
            case 10:
                return 9;
            default: 
                return 0;
        }
    }
    
    public static int GetCharacterHp(int id)
    {
        // 추후 값 밸렁싱 수정
        switch (id)
        {
            case 1: 
            case 2: 
            case 3: 
            case 4: 
            case 5: 
                return 1000;
            case 6: 
            case 7: 
            case 8:
            case 9: 
            case 10:
                return 900;
            default: 
                return 0;
        }
    }
    
    public static int GetCharacterPosition(int id)
    {
        // 추후 값 밸렁싱 수정
        switch (id)
        {
            case 1: 
            case 2: 
            case 3: 
                return 0;
            case 4: 
            case 5:
            case 6: 
            case 7: 
            case 8:
                return 1;
            case 9: 
            case 10:
                return 2;
            default: 
                return 0;
        }
    }
}
