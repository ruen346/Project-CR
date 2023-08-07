using UnityEngine;

public class GameSystem : MonoSingleton<GameSystem>
{
    public GameObject damageObject;

    public void MakeDamage(int value, Color32 color, GameObject target)
    {
        var ob = Instantiate(damageObject, target.transform.parent);
        var position = target.transform.position;
        ob.transform.position = new Vector3(position.x, position.y, -1);
        
        var damage = ob.GetComponent<Damage>();
        damage.Init(value, color);
    }
}
