using UnityEngine;

namespace Tools
{
    public class SingleBehaviour<T> : MonoBehaviour where T : Object
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = FindObjectOfType(typeof(T)) as T;

#if UNITY_EDITOR
                if (_instance is null)
                {
                    Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
                }
#endif
                return _instance;
            }
        }
    }
}


