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

    private IEnumerator Start()
    {
        returnButtonObject.SetActive(false);
        SetSlider();
        DataManager.Instance.SetExp(10);

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
        
        SetSlider();
        yield return wait;
        
        returnButtonObject.SetActive(true);
    }

    private void SetSlider()
    {
        expSlider.maxValue = DataManager.Instance.GetMaxExp();
        expSlider.value = DataManager.Instance.exp;
        expText.text = $"{DataManager.Instance.exp}/{DataManager.Instance.GetMaxExp()}";
    }

    public void OnClickReturnButton()
    {
        MenuManager.Instance.MoveScene("LobbyScene");
    }
}
