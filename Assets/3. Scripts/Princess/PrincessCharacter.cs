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
    
    public void Init(CharacterInfoData data)
    {
        characterData = data;
        
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
    }

    private Vector3 GetEndPosition()
    {
        return new(
            transform.position.x + (characterData.position == 0 ? FRONT_CHARACTER_POSITION : BACK_CHARACTER_POSITION),
            transform.position.y, 0);
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
