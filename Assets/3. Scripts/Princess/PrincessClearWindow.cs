using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrincessClearWindow : BaseWindow
{
    public List<GameObject> starObjects;
    public GameObject returnButtonObject;
    public Slider expSlider;
    public TextMeshProUGUI expText;

    private IEnumerator Start()
    {
        Init();
        
        yield return new WaitForSeconds(1f);
        int aliveCount = PrincessCharacterManager.Instance.GetAliveCount();
        
        for (int i = 0; i < 3; i++)
        {
            if (i + 3 >= aliveCount)
            {
                starObjects[i].SetActive(true);
                yield return new WaitForSeconds(1f);
            }
        }
        
        // 경험치 획득 연출
        
        yield return new WaitForSeconds(1f);
        
        returnButtonObject.SetActive(true);
    }

    private void Init()
    {
        foreach (var star in starObjects)
        {
            star.SetActive(true);
        }
        returnButtonObject.SetActive(false);
        
        expSlider.maxValue = DataManager.Instance.GetMaxExp();
        expSlider.value = DataManager.Instance.exp;
        expText.text = $"{DataManager.Instance.exp}/{DataManager.Instance.GetMaxExp()}";
        
        // 경험치 획득
    }

    public void OnClickReturnButton()
    {
        // 스테이지 선택 화면으로 돌아가기
    }
}
