using UnityEngine;
using TMPro;

public class UserGroup : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expText;

    private void Update()
    {
        nameText.text = DataManager.Instance.userName;
        levelText.text = DataManager.Instance.level.ToString();
        expText.text = $"{DataManager.Instance.exp.ToString()}/{DataManager.Instance.GetMaxExp()}";
    }
}