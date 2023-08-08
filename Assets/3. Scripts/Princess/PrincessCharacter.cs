using System.Collections;
using UnityEngine;

public class PrincessCharacter : MonoBehaviour
{
    private const float MOVE_START_TIME = 1.3f;

    // todo: 캐릭터 스텟 가져오도록 변경 (icon init 보다 빨라야함)
    public int hp;
    public int mp;
    public int maxHp;
    public int maxMp = 100;

    public bool isAlive = true;
    public Animator animator;
    public SpriteRenderer sprite;
    
    public void Init()
    {
        // todo: 캐릭터 정보를 가져오도록 수정
        maxHp = 1000;
        hp = maxHp;

        StartCoroutine(DoMoveStartPosition());
    }

    private IEnumerator DoMoveStartPosition()
    {
        var runTime = 0.0f;
        var startPosition = transform.position;
        var endPosition = new Vector3(transform.position.x + 11, transform.position.y, 0);

        while (runTime < MOVE_START_TIME)
        {
            runTime += Time.deltaTime;

            transform.position = Vector3.Lerp(startPosition, endPosition, runTime / MOVE_START_TIME);
            
            yield return null;
        }

        transform.position = endPosition;
        animator.SetTrigger("Arrival");
    }

    public void Hit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            isAlive = false;
            animator.SetTrigger("Death");
        }

        StartCoroutine(DoHitChangeColor());
        GameSystem.Instance.MakeDamage(damage, new Color32(255, 219, 0, 255), gameObject);
    }

    private IEnumerator DoHitChangeColor()
    {
        sprite.color = new Color(1, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
