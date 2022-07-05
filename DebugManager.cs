using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates a unified screen for debugging various systems. Scripts can subscribe to the <see cref="DebugUpdate"/> event to display text in the debug menu. A good alternative to just <see cref="Debug.Log(object)"/>ing everything.
/// </summary>
public class DebugManager : Singleton<DebugManager> {

	public event Action DebugUpdate;

	public bool DebugActive = false;

	public static GUIStyle Header1 { get; private set; } = new GUIStyle();
	public static GUIStyle Header2 { get; private set; } = new GUIStyle();
	public static GUIStyle Normal { get; private set; } = new GUIStyle();
	public static GUIStyle Error { get; private set; } = new GUIStyle();
	public static GUIStyle Button { get; private set; } = null;

	private void Awake() {
		Header1.normal.textColor = Color.white;
		Header1.fontSize = 20;
		Header1.fontStyle = FontStyle.Bold;

		Header2.normal.textColor = Color.white;
		Header2.fontSize = 17;
		Header2.fontStyle = FontStyle.Bold;

		Normal.normal.textColor = Color.white;
		Normal.fontSize = 16;

		Error.normal.textColor = Color.red;
		Normal.fontSize = 16;
	}

	private static void InitButtonStyle() {
		Button = GUI.skin.button;
		Button.normal.textColor = Color.white;
		Button.fontSize = 14;
	}

	private void OnGUI() {
		if(DebugActive) {
			if(Button == null) InitButtonStyle();

			GUILayout.BeginVertical();
			Delegate[] ds = DebugUpdate.GetInvocationList();
			foreach(Delegate d in ds) {
				GUILayout.Label($"{d.Method.DeclaringType.Name}", Header1);
				try {
					d.DynamicInvoke();
				} catch(Exception e) {
					GUILayout.Label($"{e.InnerException.Message}", Error);
					Debug.LogError(e.InnerException);
				}
				GUILayout.Space(8);
			}
			GUILayout.EndVertical();
		}
	}

#if DEVELOPMENT_BUILD // Keybind for debug menu should only be usable in dev builds
	private void Update() {
		if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D)) {
			DebugActive = !DebugActive;
		}
	}
#endif

}
