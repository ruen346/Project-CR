using TMPro;
using UnityEngine;

public class PauseWindow : BaseWindow
{
    public TextMeshProUGUI stageText;

    private float beforeTime;
    
    public void Init(string stage)
    {
        stageText.text = stage;
        
        beforeTime = Time.timeScale;
        Time.timeScale = 0f;
    }

    public void OnClickContinueButton()
    {
        Time.timeScale = beforeTime;
        
        OnClickCloseButton();
    }

    public void OnClickReStartButton()
    {
        Time.timeScale = 1f;
        
        MenuManager.Instance.MoveScene("PrincessScene");
    }
    
    public void OnClickReturnButton()
    {
        Time.timeScale = 1f;
        
        MenuManager.Instance.MoveScene("LobbyScene");
    }
}
