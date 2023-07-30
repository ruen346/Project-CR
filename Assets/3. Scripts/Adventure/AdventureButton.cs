using UnityEngine;

public class AdventureButton : MonoBehaviour
{
    public void OnClickButton()
    {
        MenuManager.Instance.OpenWindow("AdventureWindow");
    }
}
