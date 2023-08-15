public class PrincessFailWindow : BaseWindow
{
    public void OnClickReturnButton()
    {
        MenuManager.Instance.MoveScene("LobbyScene");
    }
}
