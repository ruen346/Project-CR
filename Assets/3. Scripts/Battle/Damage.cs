using System.Collections;
using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private const int SHOW_TIME = 1;
    
    public TextMeshPro text;
    
    public void Init(int value, Color32 color)
    {
        text.text = value.ToString();
        text.color = color;
        StartCoroutine(DoShowDamage());
    }
    
    private IEnumerator DoShowDamage()
    {
        var runTime = 0.0f;

        while (runTime < SHOW_TIME)
        {
            runTime += Time.deltaTime;
            transform.Translate(new Vector3(0, Time.deltaTime, 0));
            text.color = new Color(text.color.r, text.color.g, text.color.b, (SHOW_TIME - runTime / SHOW_TIME) * 2);
            
            yield return null;
        }

        Destroy(this);
    }
}
