using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Generic Singleton Class 
*/

public class GenericSingleton<T> : MonoBehaviour where T : Component
{
        
    private static T _instance;
    [SerializeField]
    public bool _destroyOnLoad = false;

    //publicly accessible reference to the instance
    public static T Instance
    {
        get
        {
            //check if an instance already exists
            if (_instance == null)
            {
                //if not create new instance
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }
            //if instance exists return instance
            return _instance;
        }
    }

    /// <summary>
    /// Called on awake, before the start function
    /// </summary>
    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            if (!_destroyOnLoad)
            {
                Debug.Log(gameObject.name + "Generic Singleton will NOT destroy on load");
                DontDestroyOnLoad(gameObject);
            }
            else
                Debug.Log(gameObject.name + "Generic Singleton will destroy on load");
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }
}

