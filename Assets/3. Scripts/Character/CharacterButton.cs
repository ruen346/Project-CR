using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    public void OnClickButton()
    {
        MenuManager.Instance.OpenWindow("CharacterWindow");
    }
}
