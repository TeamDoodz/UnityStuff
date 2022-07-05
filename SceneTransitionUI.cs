using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionUI : MonoBehaviour {
	public GameObject WeaponAnim;
	private AsyncOperation op;
	[SerializeField] private Slider ProgressBar;
	public void Prepare() {
		WeaponAnim.SetActive(false);
	}
	public void ShowUI(AsyncOperation operation) {
		gameObject.SetActive(true);
		op = operation;
	}
	private void Update() {
		if(op != null && !op.isDone) {
			ProgressBar.value = op.progress;
		}
	}
}