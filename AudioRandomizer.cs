using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "My Audio", menuName = "Audio Randomizer")]
public class AudioRandomizer : ScriptableObject {
	public List<AudioClip> Clips;
	private List<AudioClip> queue;

	public AudioClip GetRandomClip() {
		if(queue == null || queue.Count == 0) queue = new List<AudioClip>(Clips);
		int index = Random.Range(0, queue.Count);
		AudioClip clip = queue[index];
		queue.RemoveAt(index);
		return clip;
	}
}
