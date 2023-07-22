using UnityEngine;
using TMPro;

public class CurrencyGroup : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI diaText;

    private void Update()
    {
        goldText.text = DataManager.Instance.gold.ToString();
        diaText.text = DataManager.Instance.dia.ToString();
    }
}
