using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio Manager")]
public class AudioManager : SOSingleton<AudioManager> {
	public AudioMixerGroup MixerGroup;

	public AudioSource PlayAudio2D(AudioClip clip, float volume = 1.0f, bool destroyAfter = true) {
		var outp = PlayAudio(clip, Vector3.zero, volume: volume, destroyAfter: destroyAfter);
		//outp.rolloffMode = AudioRolloffMode.Custom;
		//outp.SetCustomCurve(AudioSourceCurveType.CustomRolloff, twoDCurve);
		return outp;
	}

	public AudioSource PlayAudio(AudioClip clip, Vector3 position, float volume = 1f, float blending = 0f, float doppler = 0f, bool destroyAfter = true) {
		GameObject go = new GameObject(clip.name);
		go.transform.position = position;

		AudioSource audio = go.AddComponent<AudioSource>();
		audio.clip = clip;
		audio.spatialBlend = blending;
		audio.dopplerLevel = doppler;
		audio.volume = volume;
		audio.outputAudioMixerGroup = MixerGroup;

		audio.Play();
		if(destroyAfter) Destroy(go, clip.length);

		return audio;
	}
}
