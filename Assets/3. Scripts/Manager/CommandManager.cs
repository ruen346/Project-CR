using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoSingleton<CommandManager>
{
    public string AddCommand(string command, string data = "")
    {
        var resultList = SplitStringByDot(data);
        
        switch (command)
        {
            case "GetUserData.php": return Server.GetUserData();
            case "GetCharacterData.php": return Server.GetCharacterData();
            case "SetExp.php": return Server.SetExp(resultList[0]);
            default: return null;
        }
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
