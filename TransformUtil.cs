using UnityEngine;

public static class TransformUtil {
	public static void ForEachChild(this Transform t, System.Action<Transform> action) {
		for(int i = 0; i < t.childCount; i++) {
			action(t.GetChild(i));
		}
	}
}
