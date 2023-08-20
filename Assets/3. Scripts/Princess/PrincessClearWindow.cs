using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrincessClearWindow : BaseWindow
{
    public List<Image> starImages;
    public GameObject returnButtonObject;
    public Slider expSlider;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI goldText;

    public void Init(int getExp, int getGold)
    {
        returnButtonObject.SetActive(false);
        SetSlider(DataManager.Instance.exp - getExp);
        SoundManager.Instance.PlaySound(SoundManager.Sound.Clear, 0.3f);

        StartCoroutine(DoViewWindow(getGold));
    }

    private IEnumerator DoViewWindow(int getGold)
    {
        var wait = new WaitForSeconds(0.5f);

        yield return wait;
        int aliveCount = PrincessCharacterManager.Instance.GetAliveCount();
        
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0: 
                    starImages[i].color = new Color(starImages[i].color.r, starImages[i].color.g, starImages[i].color.b, 1);
                    yield return wait;
                    break;
                case 1:
                case 2:
                    if (i + 3 <= aliveCount)
                    {
                        starImages[i].color = new Color(starImages[i].color.r, starImages[i].color.g, starImages[i].color.b, 1);
                        yield return wait;
                    }
                    break;
            }
        }
        
        SetSlider(DataManager.Instance.exp);
        goldText.text = $"+{getGold}G";
        yield return wait;
        
        returnButtonObject.SetActive(true);
    }

    private void SetSlider(int exp)
    {
        expSlider.maxValue = DataManager.Instance.GetMaxExp();
        expSlider.value = exp;
        expText.text = $"{DataManager.Instance.exp}/{DataManager.Instance.GetMaxExp()}";
    }

    public void OnClickReturnButton()
    {
        MenuManager.Instance.MoveScene("LobbyScene");
    }
}
