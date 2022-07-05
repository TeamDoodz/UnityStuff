using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scene Transition Manager")]
public class SceneTransitionManager : SOSingleton<SceneTransitionManager> {
	private SceneTransitionUI UI {
		get {
			if(ui == null) ui = FindObjectOfType<SceneTransitionUI>(true);
			return ui;
		}
	}
	private SceneTransitionUI ui;

	public void LoadScene(string sceneName, System.Action callback = null) {
		LoadScene(SceneManager.GetSceneByName(sceneName).buildIndex, callback);
	}
	public void LoadScene(int buildIndex, System.Action callback = null) {
		Debug.Log($"Loading level at index {buildIndex} ({SceneManager.GetSceneByBuildIndex(buildIndex).name})");
		UI.Prepare();
		AsyncOperation op = SceneManager.LoadSceneAsync(buildIndex);
		UI.ShowUI(op);
		op.completed += (_) => callback?.Invoke();
	}
	public void ReloadCurrentScene(System.Action callback = null) {
		LoadScene(SceneManager.GetActiveScene().buildIndex, callback);
	}
}
