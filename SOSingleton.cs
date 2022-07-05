using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "Doesn't Unity already have this?"
// Yes (I think), but I prefer to reinvent the wheel for simple patterns like this, since I will always understand my own implementation better than any closed-source engine code.

///<summary>
/// Mix of the <see cref="ScriptableObject"/> and <see cref="Singleton{T}"/> base classes.
///</summary>
public class SOSingleton<T> : ScriptableObject where T : SOSingleton<T> {

	public static T Instance {
		get {
			if(instance == null) instance = Resources.Load<T>(ScriptableObjectLoader<T>.GetPath() + "Instance");
			return instance;
		}
	}
	private static T instance;
	
}
