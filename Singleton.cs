using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// My implementation of a singleton. Based on https://answers.unity.com/questions/891380/unity-c-singleton.html
///</summary>
public class Singleton<T> : MonoBehaviour where T : Singleton<T> {

    public bool SetInstanceOnAwake = true;

    private void Awake() {
        _instance = GetComponent<T>();
    }

    private static T _instance;
    public static T Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<T>();

                if (_instance == null) {
                    GameObject container = new GameObject(typeof(T).FullName);
                    _instance = container.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

}
