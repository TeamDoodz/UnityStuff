using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHelper : Singleton<CoroutineHelper> {
	public void ExecuteCoroutine(object coroutine, Action? callback = null) { 
		StartCoroutine(ExecuteCoroutineAsCorutine(coroutine, callback));
	}
	private IEnumerator ExecuteCoroutineAsCorutine(object coroutine, Action? callback = null) {
		yield return coroutine;
		callback?.Invoke();
	}
}
