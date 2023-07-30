using UnityEngine;

public class MenuManager : MonoSingleton<MenuManager>
{
    private GameObject canvas;

    public GameObject OpenWindow(string name)
    {
        if (canvas == null)
        {
            canvas = GameObject.Find("Canvas");
        }
        
        var window = Instantiate(Resources.Load($"Prefab/{name}"), canvas.transform) as GameObject;
        return window;
    }
}
