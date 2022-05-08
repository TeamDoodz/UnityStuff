public static class MathUtil {
  public static float Remap(this float input, float inputMin, float inputMax, float min, float max) {
    return min + (input - inputMin) * (max - min) / (inputMax - inputMin);
  }
	
  public static bool EqualsRoughly(this Vector3 A, Vector3 other, float epsilon) {
    return Vector3.Distance(A, other) < epsilon;
  }

  public static Vector3Int Round(this Vector3 A) {
    return new Vector3Int(Mathf.RoundToInt(A.x), Mathf.RoundToInt(A.y), Mathf.RoundToInt(A.z));
  } 
}
