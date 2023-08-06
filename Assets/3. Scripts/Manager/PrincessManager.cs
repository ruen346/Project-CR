using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessManager : Singleton<PrincessManager>
{
    public void BossAttack(int damage)
    {
        TargetCharacter().Hit(damage);
    }

    private PrincessCharacter TargetCharacter()
    {
        // todo : 거리 추가 후 가장 앞에 있는 캐릭터 가져오도록 수정
        return PrincessCharacterManager.Instance.characters[0];
    }
}
