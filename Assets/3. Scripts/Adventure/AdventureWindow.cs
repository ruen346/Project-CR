public class AdventureWindow : BaseWindow
{
    public void OnClickPrincessStage()
    {
        MenuManager.Instance.OpenWindow("PrincessReadyWindow");
    }
    
    public void OnClickArchiveStage()
    {
        MenuManager.Instance.OpenMessageWindow("아카이브 스테이지", "추후 오픈될 스테이지 입니다.\n다음을 기대해 주세요", true);
    }
    
    public void OnClickStarStage()
    {
        MenuManager.Instance.OpenMessageWindow("스타 스테이지", "추후 오픈될 스테이지 입니다.\n다음을 기대해 주세요", true);
    }
}
