using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PrincessBoss : Singleton<PrincessBoss>
{
    private const float MOVE_START_TIME = 1.3f;
    
    public int maxHp = 100000;
    public int hp = 100000;
    public int level = 30;
    public int damage = 100;

    public Animator animator;
    public SpriteRenderer sprite;
    public Slider hpSlider;
    public GameObject skillObject;

    private void Start()
    {
        SetSlider();
        StartCoroutine(DoMoveStartPosition());
    }

    private void SetSlider()
    {
        hpSlider.maxValue = maxHp;
        hpSlider.value = hp;
    }

    private IEnumerator DoMoveStartPosition()
    {
        var runTime = 0.0f;
        var startPosition = transform.position;
        var endPosition = new Vector3(3.5f, startPosition.y, 0);

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
    
    private IEnumerator DoBehavior()
    {
        int attackCount = 0;
        var wait = new WaitForSeconds(2f);
        var attackDelay = new WaitForSeconds(0.5f);
        
        while (PrincessManager.Instance.isPlay)
        {
            if (attackCount < 4)
            {
                animator.SetTrigger("Attack");
                yield return attackDelay;
                PrincessManager.Instance.BossAttack(damage, 1);

                attackCount++;
            }
            else
            {
                animator.SetTrigger("Skill");
                yield return attackDelay;
                StartCoroutine(Skill());
                
                attackCount = 0;
            }

            yield return wait;
        }
    }

    private IEnumerator Skill()
    {
        var characters = PrincessManager.Instance.GetTargetCharacter(3);
        
        foreach (var character in characters)
        {
            var skill = Instantiate(skillObject, character.transform.parent);
            skill.transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 1.7f, 0);
        }
        
        yield return new WaitForSeconds(1f);
        
        PrincessManager.Instance.BossAttack(damage * 2, 3);
    }
    
    public void Hit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            animator.SetTrigger("Death");
            PrincessManager.Instance.ClearStage();
        }
        hpSlider.value = hp;

        StartCoroutine(DoHitChangeColor());
        var damagePosition = new Vector3(transform.position.x + 3, transform.position.y, 0);
        GameSystem.Instance.MakeDamage(damage, new Color32(0, 200, 255, 255), gameObject, damagePosition);
    }

    private IEnumerator DoHitChangeColor()
    {
        sprite.color = new Color(1, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
