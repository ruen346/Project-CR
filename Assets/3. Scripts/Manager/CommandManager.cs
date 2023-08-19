using System;
using System.Collections.Generic;

public class CommandManager : MonoSingleton<CommandManager>
{
    public delegate void CommandDelegate(int result, string data);
    
    public void AddCommand(string command, string data, CommandDelegate callback)
    {
        var resultList = SplitStringByDot(data);
        var responseData = "";
        
        switch (command)
        {
            case "GetUserData.php": 
                responseData = Server.GetUserData();
                break;
            case "GetCharacterData.php": 
                responseData = Server.GetCharacterData();
                break;
            case "SetExp.php": 
                responseData = Server.SetExp(resultList[0]);
                break;
            case "PrincessStart.php": 
                responseData = Server.GetBossData();
                break;
        }

        // 실제 통신시 에러 발생시 1이 아닌 값 전송
        callback(1, responseData);
    }

    private static List<string> SplitStringByDot(string input)
    {
        string[] splitArray = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        var resultList = new List<string>();

        foreach (string item in splitArray)
        {
            // 공백을 제거한 후 리스트에 추가
            string trimmedItem = item.Trim();
            if (!string.IsNullOrEmpty(trimmedItem))
            {
                resultList.Add(trimmedItem);
            }
        }

        return resultList;
    }
}
