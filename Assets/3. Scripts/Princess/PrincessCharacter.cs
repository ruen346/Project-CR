using System.Collections;
using UnityEngine;

public class PrincessCharacter : MonoBehaviour
{
    private const float MOVE_START_TIME = 1.3f;
    
    public Animator animator;
    
    private void Start()
    {
        StartCoroutine(MoveStartPosition());
    }

    private IEnumerator  MoveStartPosition()
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
}
