public class PrincessReadyWindow : BaseWindow
{
    public void OnClickStartButton()
    {
        MenuManager.Instance.MoveScene("PrincessScene");
    }
}
