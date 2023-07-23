using UnityEditor;
using UnityEngine;

public class DataTool : EditorWindow
{
    [MenuItem("Tool/DataTool")]
    public static void OpenWindow()
    {
        var window = GetWindow(typeof(DataTool));
        window.Show();
    }
    
    void OnGUI()
    {
        if (GUILayout.Button("Exp 50 획득"))
        {
            DataManager.Instance.GetExp(50);
        }
    }
}
