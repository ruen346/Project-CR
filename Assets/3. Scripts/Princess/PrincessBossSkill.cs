using System.Collections;
using UnityEngine;

public class PrincessBossSkill : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}