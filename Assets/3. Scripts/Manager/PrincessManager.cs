public class PrincessManager : Singleton<PrincessManager>
{
    public bool isPlay = true;
    
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

    public void ClearStage()
    {
        isPlay = false;
        // todo : 결과창 출력
    }

    public void FailStage()
    {
        isPlay = false;
        // todo : 결과창 출력
    }
}
