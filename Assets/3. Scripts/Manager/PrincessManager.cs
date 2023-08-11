public class PrincessManager : Singleton<PrincessManager>
{
    public void BossAttack(int damage)
    {
        TargetCharacter().Hit(damage);
    }

    private PrincessCharacter TargetCharacter()
    {
        foreach (var character in PrincessCharacterManager.Instance.characters)
        {
            if (character.isAlive)
            {
                return character;
            }
        }

        // todo : 패배 처리 추가
        return null;
    }
}
