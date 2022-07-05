using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Credit to <see href="https://stackoverflow.com/questions/4140719/calculate-median-in-c-sharp"/> for some of these functions.
/// </summary>
public static class MathUtil {

	public static float Remap(this float input, float inputMin, float inputMax, float min, float max) {
		return min + (input - inputMin) * (max - min) / (inputMax - inputMin);
	}

	/// <summary>
	/// Inverts the input percentage so <c>0f</c> becomes <c>1f</c>, <c>0.25f</c> becomes <c>0.75f</c> and so on.
	/// </summary>
	public static float InversePercent(float input) => input.Remap(0f, 1f, 1f, 0f);

	public static bool EqualsRoughly(this Vector3 A, Vector3 other, float epsilon = float.Epsilon) {
		return Vector3.Distance(A, other) < epsilon;
	}

	public static Vector3Int Round(this Vector3 A) {
		return new Vector3Int(Mathf.RoundToInt(A.x), Mathf.RoundToInt(A.y), Mathf.RoundToInt(A.z));
	}

	/// <summary>
	/// Calculates the distance between two points. Slightly faster than <see cref="Vector3.Distance(Vector3, Vector3)"/>.
	/// </summary>
	public static float FastDistance(Vector3 A, Vector3 B) {
		return (A - B).sqrMagnitude;
	}

	public static Quaternion LookAt(Vector3 A, Vector3 B) => Quaternion.LookRotation(B - A, Vector3.up);

	public static Vector3 RandVec3(bool normalize = false) => RandVec3(-Vector3.one, Vector3.one, normalize);

	public static Vector3 RandVec3(Vector3 A, Vector3 B, bool normalize = false) {
		var vector3 = new Vector3(UnityEngine.Random.Range(A.x, B.x), UnityEngine.Random.Range(A.y, B.y), UnityEngine.Random.Range(A.z, B.z));
		return normalize? vector3.normalized : vector3;
	}

	public static Vector3 Multiply(this Vector3 A, Vector3 B) {
		return new Vector3(A.x * B.x, A.y * B.y, A.z * B.z);
	}

	public static bool IsInLayerMask(int val, int mask) {
		return mask == (mask | (1 << val));
		//return mask == (mask & val);
	}

	public static float Mix(MixType type, params float[] values) {
		if(values.Length < 2) throw new InvalidOperationException("Cannot mix when there are less than two inputs.");
		return type switch {
			MixType.Additive => AddAll(values),
			MixType.Multiplicative => MultiplyAll(values),
			MixType.Maximum => Mathf.Max(values),
			MixType.Minimum => Mathf.Min(values),
			MixType.Average => Average(values),
			MixType.FirstBias => values[0],
			MixType.LastBias => values.Last(),
			_ => throw new NotImplementedException($"Mix type {type} is not implemented."),
		};
	}

	public static float AddAll(params float[] values) {
		float outp = 0f;
		foreach(var v in values) {
			outp += v;
		}
		return outp;
	}

	public static float MultiplyAll(params float[] values) {
		float outp = 0f;
		foreach(var v in values) {
			outp *= v;
		}
		return outp;
	}

	public static float Average(params float[] values) => AddAll(values) / values.Length;

	public static string AsBinaryString(this int val, string prefix = "0b") {
		return prefix + Convert.ToString(val, 2).PadLeft(32, '0');
	}
	public static string AsBinaryString(this byte val, string prefix = "0b") {
		return prefix + Convert.ToString(val, 2).PadLeft(8, '0');
	}
	public static string AsBinaryString(this long val, string prefix = "0b") {
		return prefix + Convert.ToString(val, 2).PadLeft(64, '0');
	}
	public static string AsBinaryString(this short val, string prefix = "0b") {
		return prefix + Convert.ToString(val, 2).PadLeft(16, '0');
	}
}
