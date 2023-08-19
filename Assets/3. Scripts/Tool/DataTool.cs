using UnityEditor;
using UnityEngine;

public class DataTool : EditorWindow
{
    private int bossHp;
    private int bossLevel;
    private int bossDamage;
    private string bossName;
    
    [MenuItem("Tool/DataTool")]
    public static void OpenWindow()
    {
        var window = GetWindow(typeof(DataTool));
        window.Show();
    }
    
    private void OnGUI()
    {
        GUILayout.Label("User", EditorStyles.boldLabel);
        
        if (GUILayout.Button("Exp 50 획득"))
        {
            DataManager.Instance.SetExp(50);
        }
        
        GUILayout.Label("\nBoss", EditorStyles.boldLabel);

        bossName = PlayerPrefs.GetString("bossName", "어둠의 암살자");
        bossLevel = PlayerPrefs.GetInt("bossLevel", 30);
        bossHp = PlayerPrefs.GetInt("bossHp", 100000);
        bossDamage = PlayerPrefs.GetInt("bossDamage", 100);
        
        SetBossData("Hp", "bossHp");
        SetBossData("Level", "bossLevel");
        SetBossData("Damage", "bossDamage");
        SetBossData("Name", "bossName");
    }

    private void SetBossData(string label, string key)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(label, GUILayout.MaxWidth(50));

        switch (key)
        {
            case "bossHp":
                bossHp = EditorGUILayout.IntField(bossHp);
                PlayerPrefs.SetInt(key, bossHp);
                break;
                
            case "bossLevel":
                bossLevel = EditorGUILayout.IntField(bossLevel);
                PlayerPrefs.SetInt(key, bossLevel);
                break;
                
            case "bossDamage":
                bossDamage = EditorGUILayout.IntField(bossDamage);
                PlayerPrefs.SetInt(key, bossDamage);
                break;
                
            case "bossName":
                bossName = EditorGUILayout.TextField(bossName);
                PlayerPrefs.SetString(key, bossName);
                break;
        }
        
        EditorGUILayout.EndHorizontal();
    }
}
