using UnityEngine;

public class DontDestroySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name);
                    DontDestroyOnLoad(go);
                    instance = go.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    public static bool IsInstanceExists()
    {
        return instance != null;
    }

    protected virtual void Awake()
    {
        instance = GetComponent<T>();
    }

    public static void DestroySelf()
    {
        Destroy(instance.gameObject);
        instance = null;
    }
}