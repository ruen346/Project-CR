public class DataManager : MonoSingleton<DataManager>
{
    public string userName { get; private set; }
    public int level { get; private set; }
    public int exp { get; private set; }
    public int gold { get; private set; }
    public int dia { get; private set; }
    
    // todo : 임시 데이터 세팅
    private void Awake()
    {
        userName = "이름은8자리까지";
        level = 1;
        exp = 0;
        gold = 0;
        dia = 0;
    }
    
    public void GetExp(int value)
    {
        exp += value;

        if (exp >= GetMaxExp())
        {
            exp -= GetMaxExp();
            level++;
        }
    }
    
    public int GetMaxExp()
    {
        return 100 + level * 20;
    }
}
