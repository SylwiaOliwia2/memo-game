using UnityEngine;

public abstract class FindInstanceSingleton<T> : MonoBehaviour where T : Component
{

    [SerializeField] protected bool dontDestroyOnLoad = false;

    protected static T instance;

    public static T GetInstance() => Instance;

    public static bool HasInstance => instance != null;


    public static T Instance // to jest instancja singletona
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<T>();
            }
            return instance;
        }
    }

    public void RefreshInstance()
    {
        if (instance == null)
        {
            instance = this as T;
            if (dontDestroyOnLoad)
                DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Awake()
    {
        RefreshInstance();
    }


}