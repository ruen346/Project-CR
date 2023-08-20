using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoSingleton<BackgroundManager>
{
    public Image image;
    public GameObject dialogObject;

    private bool isDialog;
    
    private void Start()
    {
        SetBackground(PlayerPrefs.GetInt("background", 8));
    }

    public void SetBackground(int id)
    {
        image.sprite = Resources.Load<Sprite>($"Texture/Character/Image/Character{id}");
    }

    public void PlayDialog()
    {
        if (!isDialog)
        {
            StartCoroutine(DoDialog());
        }
    }

    private IEnumerator DoDialog()
    {
        dialogObject.SetActive(true);
        isDialog = true;

        yield return new WaitForSeconds(3f);
        
        dialogObject.SetActive(false);
        isDialog = false;
    }
}
