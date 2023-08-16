public class LobbyManager : Singleton<LobbyManager>
{
    private void Start()
    {
        SoundManager.Instance.PlayBgm(SoundManager.Bgm.Lobby);
    }
}
