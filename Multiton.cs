using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Multiton<TKey, TValue> : MonoBehaviour where TValue : Multiton<TKey, TValue> {

	[SerializeField] private TKey m_ID;
	public TKey ID {
		get { return m_ID; }
		set { m_ID = value; }
	}

	public static Dictionary<TKey,TValue> Instances { 
		get {
			instances.PredicateRemove((x) => x.Value == null);
			return instances;
		}
	}
	private static Dictionary<TKey, TValue> instances = new Dictionary<TKey, TValue>();

	protected void Awake() {
		if(Instances.ContainsKey(m_ID)) {
			Debug.LogWarning($"Can't assign an ID of {m_ID} to {gameObject} because {Instances[m_ID]} already has that ID.");
			return;
		}
		Instances.Add(m_ID, GetComponent<TValue>());
	}

}
