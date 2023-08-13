using System.Collections;
using UnityEngine;

public class PrincessCharacter : MonoBehaviour
{
    private const float MOVE_START_TIME = 1.3f;
    private const int FRONT_CHARACTER_POSITION = 12;
    private const int BACK_CHARACTER_POSITION = 10;
    
    public int hp;
    public int mp;
    public int maxHp;
    public int maxMp = 100;

    public bool isAlive = true;
    public Animator animator;
    public SpriteRenderer sprite;

    private CharacterInfoData characterData;
    private int sequence; // 앞에서 부터 0~4
    private bool isSkill;
    
    public void Init(CharacterInfoData data, int count)
    {
        characterData = data;
        sequence = count;
        
        maxHp = data.hp;
        hp = maxHp;

        StartCoroutine(DoMoveStartPosition());
    }

    private IEnumerator DoMoveStartPosition()
    {
        var runTime = 0.0f;
        var startPosition = transform.position;
        var endPosition = GetEndPosition();

        while (runTime < MOVE_START_TIME)
        {
            runTime += Time.deltaTime;

            transform.position = Vector3.Lerp(startPosition, endPosition, runTime / MOVE_START_TIME);
            
            yield return null;
        }

        transform.position = endPosition;
        animator.SetTrigger("Arrival");
        StartCoroutine(DoBehavior());
    }

    private Vector3 GetEndPosition()
    {
        return new(
            transform.position.x + (characterData.position == 0 ? FRONT_CHARACTER_POSITION : BACK_CHARACTER_POSITION),
            transform.position.y, 0);
    }
    
    private IEnumerator DoBehavior()
    {
        var wait = new WaitForSeconds(1.8f);
        var attackDelay = new WaitForSeconds(0.5f);
        var isNotSkill = new WaitUntil(() => !isSkill);

        yield return new WaitForSeconds(GetBehaviorDelay());
        
        while (PrincessManager.Instance.isPlay && isAlive)
        {
            animator.SetTrigger("Attack");
            yield return attackDelay;
            mp += 10;
            PrincessBoss.Instance.Hit(characterData.damage);

            yield return isNotSkill;
            yield return wait;
        }
    }

    /// <summary>
    /// 편성 위치에 따른 첫 행동 딜레이
    /// </summary>
    /// <returns>딜레이 시간</returns>
    private float GetBehaviorDelay()
    {
        return sequence * 0.3f;
    }

    public void OnSkill()
    {
        if (mp >= maxMp && PrincessManager.Instance.isPlay && isAlive)
        {
            mp = 0;
            StartCoroutine(DoSkill());
        }
    }
    
    private IEnumerator DoSkill()
    {
        var runTime = 0.0f;
        var isAction = false;
        var startPosition = transform.position;
        var endPosition = new Vector3(PrincessBoss.Instance.transform.position.x, transform.position.y, 0);
        
        isSkill = true;
        animator.SetTrigger("Skill");

        while (runTime < 1f)
        {
            if (runTime < 0.15f)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, runTime / 0.15f);
            }
            else if(runTime < 0.8f && !isAction)
            {
                PrincessBoss.Instance.Hit(characterData.damage * 3);
                isAction = true;
            }
            else
            {
                transform.position = Vector3.Lerp(endPosition, startPosition, (runTime - 0.8f) / 0.2f);
            }
            
            runTime += Time.deltaTime;
            yield return null;
        }
        
        isSkill = false;
    }

    public void Hit(int damage)
    {
        hp -= damage;
        mp += 15;
        
        if (hp <= 0)
        {
            hp = 0;
            isAlive = false;
            animator.SetTrigger("Death");

            if (PrincessCharacterManager.Instance.IsAllCharacterDeath())
            {
                PrincessManager.Instance.FailStage();
            }
        }

        StartCoroutine(DoHitChangeColor());
        GameSystem.Instance.MakeDamage(damage, new Color32(255, 219, 0, 255), gameObject, transform.position);
    }

    private IEnumerator DoHitChangeColor()
    {
        sprite.color = new Color(1, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
