using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : TriggerBase {
	public UnityEvent OnTriggered;

	public override void DoTheThing() {
		OnTriggered?.Invoke();
	}
}
