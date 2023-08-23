using UnityEngine;
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(T)) as T;
            
            if (instance == null)
            {
                instance = new GameObject ("@"+typeof(T),
                    typeof(T)).AddComponent<T>();
            }

            return instance;
        }
    }
}
