using System.Collections;
using System.Collections.Generic;
using DoomlikeGame;
using UnityEngine;

public class AutoDisablePhysics : MonoBehaviour {

	public float Time = 2f;
	public float Threshold = 0.05f;
	public float CheckFrequency = 0.5f;

	private void Awake() {
		InvokeRepeating(nameof(LazyUpdate), 0f, CheckFrequency);
	}

	private float timer = 0f;
	private void LazyUpdate() {
		if(GetComponent<Rigidbody>().velocity.magnitude <= Threshold) {
			timer += CheckFrequency;
			if(timer >= Time) {
				Destroy(GetComponent<Rigidbody>());
				Destroy(GetComponent<Collider>());
				var room = GetComponent<RoomOccupier>();
				if(room != null) {
					room.DoCheck = false;
				}
				Destroy(this);
			}
		} else {
			timer = 0f;
		}
	}
	
}
