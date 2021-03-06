using System.Linq;
using UnityEngine;

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (!instance)
#if UNITY_EDITOR
                instance = Resources.LoadAll<T>("").FirstOrDefault();
#else
                instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
#endif

            return instance;
        }
    }
}