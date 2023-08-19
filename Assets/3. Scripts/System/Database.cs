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
        switch (id)
        {
            case 2:
            case 6:
            case 9: return 0;
            default: return 1;
        }
    }
    
    public static string GetCharacterName(int id)
    {
        switch (id)
        {
            case 1: return "프레아";
            case 2: return "카난";
            case 3: return "아논";
            case 4: return "시즈루";
            case 5: return "이즈나";
            case 6: return "플레어";
            case 7: return "메리";
            case 8: return "라미";
            case 9: return "티아나";
            case 10: return "코토";
            default: return "";
        }
    }
    
    public static int IsCharacterStar(int id)
    {
        switch (id)
        {
            case 1: 
            case 2: 
            case 5: 
            case 6: 
            case 9: 
                return 1;
            case 3: 
            case 7: 
            case 10:
                return 2;
            case 4: 
            case 8:
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
                return 600;
            case 5:
            case 6: 
            case 7: 
            case 8:
                return 1000;
            case 9: 
            case 10:
                return 400;
            default: 
                return 0;
        }
    }
    
    public static int GetCharacterHp(int id)
    {
        switch (id)
        {
            case 1: 
            case 2: 
            case 3:
            case 4: 
                return 2000;
            case 5:
            case 6: 
            case 7: 
            case 8:
                return 1000;
            case 9: 
            case 10:
                return 800;
            default: 
                return 0;
        }
    }
    
    public static int GetCharacterPosition(int id)
    {
        switch (id)
        {
            case 1: 
            case 2: 
            case 3:
            case 4: 
                return 0;
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
    
    public static int GetMaxExp(int level)
    {
        return 100 + level * 20;
    }
}
