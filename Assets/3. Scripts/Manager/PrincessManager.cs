using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrincessManager : Singleton<PrincessManager>
{
    public Image autoButtonImage;
    
    public bool isPlay { get; private set; } = true;
    public bool isAuto { get; private set; }
    
    public void BossAttack(int damage, int targetCount)
    {
        var characters = GetTargetCharacter(targetCount);

        if (characters.Count > 0)
        {
            foreach (var character in characters)
            {
                character.Hit(damage);
            }
        }
    }

    public List<PrincessCharacter> GetTargetCharacter(int targetCount)
    {
        var characters = new List<PrincessCharacter>();
        int count = 0;
        
        foreach (var character in PrincessCharacterManager.Instance.characters)
        {
            if (character.isAlive)
            {
                characters.Add(character);
                count++;

                if (count == targetCount)
                {
                    break;
                }
            }
        }
        
        return characters;
    }

    public void ClearStage()
    {
        if (isPlay)
        {
            isPlay = false;
            StartCoroutine(OpenClearWindow());
        }
    }

    private IEnumerator OpenClearWindow()
    {
        yield return new WaitForSeconds(2f);
        
        MenuManager.Instance.OpenWindow("PrincessClearWindow");
    }

    public void FailStage()
    {
        if (isPlay)
        {
            isPlay = false;
            StartCoroutine(OpenFailWindow());
        }
    }
    
    private IEnumerator OpenFailWindow()
    {
        yield return new WaitForSeconds(2f);
        
        MenuManager.Instance.OpenWindow("PrincessFailWindow");
    }
    
    public void OnClickAutoButton()
    {
        isAuto = !isAuto;

        autoButtonImage.color = isAuto ? Color.white : Color.gray;
    }
}
