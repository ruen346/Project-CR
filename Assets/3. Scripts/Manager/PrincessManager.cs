using System.Collections.Generic;

public class PrincessManager : Singleton<PrincessManager>
{
    public bool isPlay = true;
    
    public void BossAttack(int damage, int targetCount)
    {
        var characters = GetTargetCharacter(targetCount);

        if (characters.Count > 0)
        {
            foreach (var character in characters)
            {
                character.Hit(damage);
            }
        }
    }

    public List<PrincessCharacter> GetTargetCharacter(int targetCount)
    {
        var characters = new List<PrincessCharacter>();
        int count = 0;
        
        foreach (var character in PrincessCharacterManager.Instance.characters)
        {
            if (character.isAlive)
            {
                characters.Add(character);
                count++;

                if (count == targetCount)
                {
                    break;
                }
            }
        }
        
        return characters;
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
