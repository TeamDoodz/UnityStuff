using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Modal Displayer")]
public class ModalDisplayer : SOSingleton<ModalDisplayer> {
	[SerializeField] private GameObject ConfirmPrefab;

	public void CreateConfirmWindow(System.Action<ConfirmWindow> OnCreated = null, System.Action OnYes = null, System.Action OnNo = null) {
		var go = Instantiate(ConfirmPrefab);
		go.transform.SetParent(MainCanvasIdentifier.Instance.transform, false);
		var window = go.GetComponent<ConfirmWindow>();

		GameSpeedManager.Instance.TimePaused = true;

		OnCreated?.Invoke(window);

		window.YesPressed += () => {
			OnYes?.Invoke();
			GameSpeedManager.Instance.TimePaused = false;
		};
		window.NoPressed += () => {
			OnNo?.Invoke();
			GameSpeedManager.Instance.TimePaused = false;
		};
	}
}
