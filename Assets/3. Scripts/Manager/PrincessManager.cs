using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrincessManager : Singleton<PrincessManager>
{
    public Image autoButtonImage;
    public Image speed2xButtonImage;
    
    public bool isPlay { get; private set; } = true;
    public bool isAuto { get; private set; }
    
    private bool isSpeed2x;
    
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
            SetEndStage();
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
            SetEndStage();
            StartCoroutine(OpenFailWindow());
        }
    }
    
    private IEnumerator OpenFailWindow()
    {
        yield return new WaitForSeconds(2f);
        
        MenuManager.Instance.OpenWindow("PrincessFailWindow");
    }

    private void SetEndStage()
    {
        isPlay = false;
        Time.timeScale = 1f;
    }
    
    public void OnClickAutoButton()
    {
        isAuto = !isAuto;

        autoButtonImage.color = isAuto ? Color.white : Color.gray;
    }
    
    public void OnClickSpeed2xButton()
    {
        isSpeed2x = !isSpeed2x;
        Time.timeScale = isSpeed2x ? 2f : 1f;

        speed2xButtonImage.color = isSpeed2x ? Color.white : Color.gray;
    }
}
