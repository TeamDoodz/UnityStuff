using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHierarchyFlatten : MonoBehaviour {

	private void Awake() {
		/*
		for(int i=0; i<transform.childCount; i++) {
			transform.GetChild(i).parent = transform.parent;
		}
		Destroy(gameObject);
		*/
	}

	private void Update() {
		if(transform.childCount == 0) Destroy(gameObject);
	}

}
