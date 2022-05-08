public static class MathUtil {
  public static float Remap(this float input, float inputMin, float inputMax, float min, float max) {
		return min + (input - inputMin) * (max - min) / (inputMax - inputMin);
	}
}
