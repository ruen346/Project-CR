public class PrincessCharacterBattleIcon : PrincessCharacterIcon
{
    private PrincessCharacter character;
    
    public void Init(PrincessCharacter character)
    {
        this.character = character;
        
        hpSlider.maxValue = character.maxHp;
        mpSlider.maxValue = character.maxMp;
    }
    
    private void Update()
    {
        hpSlider.value = character.hp;
        mpSlider.value = character.mp;
    }

    public void OnClickIcon()
    {
        
    }
}
