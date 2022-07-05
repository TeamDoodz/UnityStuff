using UnityEngine;

[System.Serializable]
public struct MinMaxInt {
	[Tooltip("Inclusive minimum.")]
	public int Min;
	[Tooltip("Exclusive maximum.")]
	public int Max;

	public MinMaxInt(int min, int max) {
		Min = min;
		Max = max;
	}

	public int GetValue() {
		return Random.Range(Min, Max);
	}
}
