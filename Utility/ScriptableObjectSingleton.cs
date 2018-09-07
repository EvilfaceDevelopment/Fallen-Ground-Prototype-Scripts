using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace Assets.Scripts
{
    /// <summary>
    /// Persistant scriptable object singleton
    /// </summary>
    /// <typeparam name="T"> Singleton type</typeparam>

    public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
    {
        static T _instance = null;

        public static T Instance
        {
            get
            {
                if (!_instance)
                    _instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
                return _instance;
            }

        }
    }
}



