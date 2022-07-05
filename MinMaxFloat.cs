using UnityEngine;

[System.Serializable]
public struct MinMaxFloat {
	[Tooltip("Inclusive minimum.")]
	public float Min;
	[Tooltip("Inclusive maximum.")]
	public float Max;

	public MinMaxFloat(float min, float max) {
		Min = min;
		Max = max;
	}

	public float GetValue() {
		return Random.Range(Min, Max);
	}
}
