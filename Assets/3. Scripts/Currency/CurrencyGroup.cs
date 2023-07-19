using TMPro;

public class CurrencyGroup : Singleton<CurrencyGroup>
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI diaText;

    private void Update()
    {
        goldText.text = DataManager.Instance.gold.ToString();
        diaText.text = DataManager.Instance.dia.ToString();
    }
}
