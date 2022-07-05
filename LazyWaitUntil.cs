using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyWaitUntil : CustomYieldInstruction {

	private float wait;
	private System.Func<bool> predicate;

	private float lastCheckTime;
	public float TimeSinceLastCheck => Time.realtimeSinceStartup - lastCheckTime;

	public LazyWaitUntil(System.Func<bool> Condition, float WaitTime = 0.1f) {
		predicate = Condition;
		wait = WaitTime;
		lastCheckTime = Time.realtimeSinceStartup;
	}

	public override bool keepWaiting {
		get {
			if(TimeSinceLastCheck >= wait) {
				lastCheckTime = Time.realtimeSinceStartup;
				return !predicate.Invoke();
			}
			return true;
		}
	}
}
