using System.Collections;
using System.Collections.Generic;
using DoomlikeGame;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Activates some code when a valid collider enters the trigger.
/// </summary>
public abstract class TriggerBase : Multiton<int, TriggerBase> {
	public List<string> AllowedTags;
	public TriggerType Type;
	public virtual bool RespondsToTrigger(Collider other) {
		return AllowedTags.Find((x) => other.CompareTag(x)) != null;
	}
	public abstract void DoTheThing();
	protected void OnTriggerEnter(Collider other) {
		if(RespondsToTrigger(other)) {
			DoTheThing();
			if(Type == TriggerType.Once) {
				TriggerSaver.Instance.UsedTriggers.Add(ID);
				Destroy(gameObject);
			}
		}
	}
}