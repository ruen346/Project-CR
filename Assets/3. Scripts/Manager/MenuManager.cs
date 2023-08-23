using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : DontDestroySingleton<MenuManager>
{
    private GameObject canvas;
    private GameObject topCanvas;

    public GameObject OpenWindow(string name, bool isTopCanvas = false)
    {
        if (canvas == null)
        {
            canvas = GameObject.Find("Canvas");
        }
        if (topCanvas == null)
        {
            topCanvas = GameObject.Find("TopCanvas");
        }

        var window =
            Instantiate(Resources.Load($"Prefab/{name}"),
                isTopCanvas ? topCanvas.transform : canvas.transform) as GameObject;
        return window;
    }

    public GameObject OpenMessageWindow(string title, string content, bool isTopCanvas = false)
    {
        var window = OpenWindow("MessageWindow", isTopCanvas);
        window.GetComponent<MessageWindow>().Init(title, content);

        return window;
    }

    public void MoveScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
