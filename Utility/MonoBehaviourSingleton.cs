using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{

    /// <summary>
    /// Lazy instantiation of a singleton for Monobehaviours
    /// </summary>
    public static MonoBehaviourSingleton<T> Instance;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
