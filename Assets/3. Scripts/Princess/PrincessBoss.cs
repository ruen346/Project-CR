using System.Collections;
using UnityEngine;

public class PrincessBoss : MonoBehaviour
{
    private const float MOVE_START_TIME = 1.3f;
    
    public int maxHp = 100000;
    public int hp = 100000;
    public int level = 30;

    public Animator animator;
    
    private void Start()
    {
        StartCoroutine(MoveStartPosition());
    }

    private IEnumerator MoveStartPosition()
    {
        var runTime = 0.0f;
        var startPosition = transform.position;
        var endPosition = new Vector3(3.5f, 3, 0);

        while (runTime < MOVE_START_TIME)
        {
            runTime += Time.deltaTime;

            transform.position = Vector3.Lerp(startPosition, endPosition, runTime / MOVE_START_TIME);
            
            yield return null;
        }

        transform.position = endPosition;
        animator.SetTrigger("Arrival");
    }
}
