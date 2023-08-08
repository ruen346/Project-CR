using System.Collections;
using UnityEngine;

public class PrincessBoss : MonoBehaviour
{
    private const float MOVE_START_TIME = 1.3f;
    
    public int maxHp = 100000;
    public int hp = 100000;
    public int level = 30;
    public int damage = 100;

    public Animator animator;
    
    private void Start()
    {
        StartCoroutine(DoMoveStartPosition());
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
        
        while (true)
        {
            if (attackCount < 10)
            {
                animator.SetTrigger("Attack");
                yield return attackDelay;
                PrincessManager.Instance.BossAttack(damage);
            }
            else
            {
                // todo : 스킬 발동
                attackCount = 0;
            }

            yield return wait;
        }
    }
}
