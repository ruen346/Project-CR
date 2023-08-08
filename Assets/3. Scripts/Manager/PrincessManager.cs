public class PrincessManager : Singleton<PrincessManager>
{
    public void BossAttack(int damage)
    {
        TargetCharacter().Hit(damage);
    }

    private PrincessCharacter TargetCharacter()
    {
        // todo : 거리 추가 후 가장 앞에 있는 캐릭터 가져오도록 수정
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
