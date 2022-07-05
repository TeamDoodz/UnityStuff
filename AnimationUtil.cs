using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationUtil {
	public static IEnumerator PlayAsCoroutine(this Animator Anim, string Name, System.Action? callback = null) {
		Anim.Play(Name);
		yield return new WaitForEndOfFrame(); // For some reason duration of current is not updated until the next frame begins
		yield return new WaitForSeconds(Anim.GetCurrentAnimatorStateInfo(0).length);
		callback?.Invoke();
	}
}
