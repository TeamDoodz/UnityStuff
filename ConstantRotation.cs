using System;
using UnityEngine;

public class ConstantRotation : MonoBehaviour {
	public Quaternion rotation;

	private void LateUpdate() {
		transform.rotation = rotation;
	}
}
