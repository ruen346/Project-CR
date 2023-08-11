using System;
using System.Collections.Generic;
using System.Linq;
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

    public void MakeDamage(int value, Color32 color, GameObject target, Vector3 viewPosition)
    {
        var ob = Instantiate(damageObject, target.transform.parent);
        var position = viewPosition;
        ob.transform.position = new Vector3(position.x, position.y, -1);
        
        var damage = ob.GetComponent<Damage>();
        damage.Init(value, color);
    }

    public void SetPrincessCharacter(List<CharacterInfoData> datas)
    {
        characterInfoDatas = datas.OrderBy(data => data.position).ToList();
        MenuManager.Instance.MoveScene("PrincessScene");
    }
}
