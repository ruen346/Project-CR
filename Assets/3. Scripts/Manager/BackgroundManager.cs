using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoSingleton<BackgroundManager>
{
    public Image image;
    
    private void Start()
    {
        SetBackground(PlayerPrefs.GetInt("background", 8));
    }

    public void SetBackground(int id)
    {
        image.sprite = Resources.Load<Sprite>($"Texture/Character/Image/Character{id}");
    }
}
