using System.Collections.Generic;
using UnityEngine;

public static class GameObjectUtils {
	public static void RemoveComponent<T>(this GameObject obj, float delay = 0f) where T : Component {
		Object.Destroy(obj.GetComponent<T>(), delay);
	}
	public static void RemoveComponent<T>(this Component obj, float delay = 0f) where T : Component {
		Object.Destroy(obj.GetComponent<T>(), delay);
	}

	public static GameObject CreatePrimitiveNoCollision(PrimitiveType Type) {
		GameObject gameObject = Object.Instantiate(PrimitivesBank.Instance.GetPrimitive(Type.ToString()));
		if(gameObject == null) throw new System.NotImplementedException();
		return gameObject;
	}

	public static void RecursiveSetParent(this Transform T, Transform parent) {
		if(T.childCount != 0) {
			List<Transform> ToSet = new List<Transform>();
			for(int i = 0; i < T.childCount; i++) {
				ToSet.Add(T.GetChild(i));
			}
			foreach(var child in ToSet) {
				child.RecursiveSetParent(parent);
			}
		}
		T.parent = parent;
	}
}
