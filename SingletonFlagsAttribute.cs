using UnityEngine;

[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
public class SingletonFlagsAttribute : System.Attribute {
	[System.Flags]
	public enum Flags {
		None = 0,
		/// <summary>
		/// Prevent an instance of this singleton from being made automatically if no instance exists.
		/// </summary>
		NoAutoInstance = 1,
		/// <summary>
		/// Automatic instances of this singleton will not be marked as <see cref="Object.DontDestroyOnLoad(Object)"/>. Does nothing if <see cref="NoAutoInstance"/> is enabled.
		/// </summary>
		VolatileAutoInstance = 2,
	}
	public Flags flags;
	public SingletonFlagsAttribute() {
	}
}
