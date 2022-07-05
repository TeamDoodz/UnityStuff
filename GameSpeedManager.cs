using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[SingletonFlags(flags = SingletonFlagsAttribute.Flags.VolatileAutoInstance)] // reset values on scene load
public class GameSpeedManager : Singleton<GameSpeedManager> {

	private const string PARAM_PITCH = "Pitch";

	public float MoveRate = 5f;

	public float GameSpeed { get; set; }

	public bool TimePaused { get; set; }

	[SerializeField] private AudioMixer mixer;
	private void Awake() {
		GameSpeed = Time.timeScale;
		if(mixer == null) mixer = AudioManager.Instance.MixerGroup.audioMixer;
	}

	private float TargetSpeed => TimePaused? 0f : GameSpeed;

	private void Update() {
		float maxDelta = Time.unscaledDeltaTime * MoveRate;

		Time.timeScale = Mathf.MoveTowards(Time.timeScale, TargetSpeed, maxDelta);

		float pitch;
		if(mixer.GetFloat(PARAM_PITCH, out pitch)) {
			mixer.SetFloat(PARAM_PITCH, Mathf.MoveTowards(pitch, TargetSpeed, maxDelta));
		}
	}

}
