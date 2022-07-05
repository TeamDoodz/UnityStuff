using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<TState> : MonoBehaviour { 
	public TState CurrentState { get; set; }

	protected Dictionary<TState, Action> StateUpdate;

	protected void Update() {
		if(StateUpdate.ContainsKey(CurrentState)) {
			StateUpdate[CurrentState].Invoke();
		} else {
			Debug.LogWarning($"State {CurrentState} does not have a {nameof(StateUpdate)} implementation.");
			CurrentState = default;
		}
	}

	protected void OnDestroy() {
		if(StateUpdate != null) StateUpdate.Clear();
	}
}
