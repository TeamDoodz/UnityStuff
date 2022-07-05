using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// hacky as fuck but whatever
/// </summary>
public class RectTransformLockPosition : MonoBehaviour {
    
	private RectTransform RectTransform;
	[SerializeField] private Vector3 Position;
	[SerializeField] private bool setPos = false;

	/*
	private void OnDrawGizmosSelected() {
		Position = GetComponent<RectTransform>().position;
	}
	*/

	private void Awake() {
		//yield return new WaitForEndOfFrame();
		RectTransform = GetComponent<RectTransform>();
		if(setPos) {
			Position = RectTransform.position;
		}
		//yield break;
	}

	private void LateUpdate() {
		RectTransform.position = Position;
	}

#if UNITY_EDITOR
	[NaughtyAttributes.Button("Log Position")]
	private void LogPos() {
		Debug.Log(GetComponent<RectTransform>().position);
	}
#endif

}
