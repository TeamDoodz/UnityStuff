using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using NaughtyAttributes;

///<summary>
/// My implementation of a singleton. Based on https://answers.unity.com/questions/891380/unity-c-singleton.html
///</summary>
public class Singleton<T> : MonoBehaviour where T : Singleton<T> {

	static Singleton() {
		SingletonFlagsAttribute attribute = typeof(T).GetCustomAttribute<SingletonFlagsAttribute>(true);
		if(attribute == null) {
			Flags = 0;
		} else {
			Flags = attribute.flags;
		}
	}

	public static SingletonFlagsAttribute.Flags Flags { get; private set; }

    private static T _instance;
    public static T Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<T>();

                if (_instance == null && !Flags.HasFlag(SingletonFlagsAttribute.Flags.NoAutoInstance)) {
					Debug.Log($"Singleton {typeof(T).FullName} does not exist. Creating!");
                    GameObject container = new GameObject(typeof(T).FullName);
                    _instance = container.AddComponent<T>();
					if(!Flags.HasFlag(SingletonFlagsAttribute.Flags.VolatileAutoInstance)) DontDestroyOnLoad(container);
                }
            }

            return _instance;
        }
    }

}
