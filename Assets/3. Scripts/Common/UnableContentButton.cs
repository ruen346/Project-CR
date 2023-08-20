using UnityEngine;

public class UnableContentButton : MonoBehaviour
{
    public void OnClickButton()
    {
        MenuManager.Instance.OpenMessageWindow("미 오픈 컨텐츠", "추후 오픈될 컨텐츠 입니다.", true);
    }
}
