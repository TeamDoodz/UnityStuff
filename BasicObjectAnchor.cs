using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObjectAnchor : MonoBehaviour {

	public Transform target;

	private void Update() {
		target.position = transform.position;
	}

}
