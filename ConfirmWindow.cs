using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConfirmWindow : MonoBehaviour {

	[SerializeField] private TMP_Text Title; 
	[SerializeField] private TMP_Text Warning;
	[SerializeField] private Button YesButton;
	[SerializeField] private Button NoButton;

	public event System.Action YesPressed;
	public event System.Action NoPressed;

	public void SetButtonsInteractable(bool? YesActive = null, bool? NoActive = null) {
		if(YesActive != null) {
			YesButton.interactable = YesActive.Value;
		}
		if(NoActive != null) {
			NoButton.interactable = NoActive.Value;
		}
	}

	public void SetTitle(string text) => Title.text = text;
	public void SetWarning(string text) => Warning.text = text;

	public void Yes() {
		YesPressed?.Invoke();
		Destroy(gameObject);
	}

	public void No() {
		NoPressed?.Invoke();
		Destroy(gameObject);
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Return)) {
			Yes();
		}
		if(Input.GetKeyDown(KeyCode.Escape)) {
			No();
		}
	}

}
