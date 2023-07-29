using UnityEngine;
using TMPro;

public class CurrencyGroup : MonoBehaviour
{
    private const int MAX_ENERGY_VALUE = 100;
    
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI diaText;

    private void Update()
    {
        energyText.text = $"{DataManager.Instance.energy.ToString()}/{MAX_ENERGY_VALUE}";
        goldText.text = DataManager.Instance.gold.ToString();
        diaText.text = DataManager.Instance.dia.ToString();
    }
}
