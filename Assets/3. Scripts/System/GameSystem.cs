using System;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance;
    
    public GameObject damageObject;

    [HideInInspector] 
    public List<CharacterInfoData> characterInfoDatas;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void MakeDamage(int value, Color32 color, GameObject target)
    {
        var ob = Instantiate(damageObject, target.transform.parent);
        var position = target.transform.position;
        ob.transform.position = new Vector3(position.x, position.y, -1);
        
        var damage = ob.GetComponent<Damage>();
        damage.Init(value, color);
    }

    public void SetPrincessCharacter(List<CharacterInfoData> datas)
    {
        characterInfoDatas = datas;
        MenuManager.Instance.MoveScene("PrincessScene");
    }
}
