public class PrincessCharacterBattleIcon : PrincessCharacterIcon
{
    private void Start()
    {
        // todo: 캐릭터 스텟으로 변경
        hpSlider.maxValue = 1;
        mpSlider.maxValue = 100;
    }
    
    private void Update()
    {
        // todo: 캐릭터 스텟으로 변경
        hpSlider.value = 1;
        mpSlider.value = 0;
    }

    public void OnClickIcon()
    {
        
    }
}
